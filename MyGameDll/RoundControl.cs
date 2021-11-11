using MyGameDll.Abstract;
using MyGameDll.Interface;
using MyGameDll.Model.Dto;
using MyGameDll.Model.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class RoundControl : MonoBehaviour
    {
        public void DoRefresh()
        {
            if (GlobalObject.CurOperation == OperationType.GamePanleControl)
            {

                Battle(RoundTypeEnum.Player);

                CreatEnemy();

                EnemyMove();

                Battle(RoundTypeEnum.Enemy);

                CreatMaterials();

                RefreshNodeCamp();

                RefreshOperation();

            }

        }

        private void EnemyMove()
        {
            foreach (Transform team in GameObject.Find("Enemys").transform)
            {
                AbstractTeam Team = team.GetComponent<AbstractTeam>();
                AbstractNode CurNode = Team.CurNode.GetComponent<AbstractNode>();

                int i = 0;
                while (Team.Operater > 0 && i <5)
                {
                    foreach (GameObject go in CurNode.NextNode)
                    {
                        if (Team.CanMoveTo(go))
                        {
                            Team.DoMoveTo(go);
                            break;
                        }
                    }
                    i++;
                }



            }
        }

        public void RefreshNodeCamp()
        {
            foreach(Transform TeamType in GameObject.Find("Chess").transform)
            {
                foreach(Transform team in TeamType)
                {
                    team.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().Camp = team.GetComponent<AbstractTeam>().Camp;
                }
            }

            foreach (Transform team in GameObject.Find("Enemys").transform)
            {
                team.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().Camp = team.GetComponent<AbstractTeam>().Camp;

            }

        }

        public void CreatMaterials()
        {
            HashSet<GameObject> list = BaseFunc.GetNullNodeList(3, true);
            GameObject layerPrefab = Resources.Load("Prefab/Material") as GameObject;

            foreach (GameObject item in list)
            {
                GameObject go = Instantiate(layerPrefab, GameObject.Find("Materials").transform, true);
                Vector3 newposition = new Vector3(item.transform.position.x, item.transform.position.y, -5);
                go.transform.position = newposition;

                item.GetComponent<AbstractNode>().OtherObject = go;
                go.GetComponent< MaterialScript >().CurNode = item;
            }
        }

        public void CreatEnemy()
        {
            HashSet<GameObject> list = BaseFunc.GetNullNodeList(3, false);
            
            foreach(GameObject item in list)
            {
                TeamData team = new TeamData();
                team.Camp = CampEnum.Enemy;
                team.BaseNumber = 2;
                team.BaseView = 2;

                TeamCreat.CreatTeam(item, team);
            }
        }

        public void Battle(RoundTypeEnum RoundType)
        {

            HashSet<GameObject> list =  GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode;

            List<GameObject> Golist = new List<GameObject>();

            CampEnum PlayerCamp = CampEnum.None;
            CampEnum EnemyCamp = CampEnum.None;


            if (RoundType == RoundTypeEnum.Player)
            {
                PlayerCamp = CampEnum.Player;
                EnemyCamp = CampEnum.Enemy;
            }
            else if (RoundType == RoundTypeEnum.Enemy)
            {
                PlayerCamp = CampEnum.Enemy;
                EnemyCamp = CampEnum.Player;

            }

            #region 普通战斗
            while (list.Count>0)
            {
                GameObject Node = list.First();
                int AttackCount = 0;
                int DefentCount = 0;
                TeamList CurTeam = Node.GetComponent<AbstractNode>().CurTeam;
                List<GameObject> FireSupport = Node.GetComponent<AbstractNode>().FireSupport;


                foreach (GameObject Team in CurTeam)
                {
                    if (Team.GetComponent<AbstractTeam>().Camp == PlayerCamp)
                    {
                        AttackCount += Team.GetComponent<AbstractTeam>().Attack;
                    }
                    else if (Team.GetComponent<AbstractTeam>().Camp == EnemyCamp)
                    {
                        DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                    }

                }
                foreach (GameObject Team in FireSupport)
                {
                    ISupport supportTeam = Team.GetComponent<ISupport>();
                    if (supportTeam != null)
                    {
                        if (supportTeam.BelongCamp == PlayerCamp)
                        {
                            AttackCount += supportTeam.FireSupport;
                        }
                        else if (supportTeam.BelongCamp == EnemyCamp)
                        {
                            DefentCount += supportTeam.FireSupport;
                        }
                        supportTeam.IsWasSupport = true;

                    }

                }

                double dif = 0;
                if (AttackCount > DefentCount)
                {
                    Golist.AddRange(CurTeam.Remove(EnemyCamp));
                    dif = DefentCount / (double)AttackCount;
                }
                else
                {
                    Golist.AddRange(CurTeam.Remove(PlayerCamp));
                    dif = AttackCount / (double)DefentCount;
                }
                foreach(GameObject Team in CurTeam)
                {
                    Team.GetComponent<AbstractTeam>().BaseNumber = (int)(Team.GetComponent<AbstractTeam>().BaseNumber * (1- dif));
                }

            }
            foreach(GameObject go in Golist)
            {
                Destroy(go);
            }
            #endregion

            #region 支援战斗
            DoSupport("SniperTeams", EnemyCamp);
            DoSupport("AirTeams", EnemyCamp);
            DoSupport("ArtilleryTeams", EnemyCamp);
            DoSupport("Turrets", EnemyCamp);

            #endregion



        }

        private void DoSupport(string ObjectName, CampEnum EnemyCamp)
        {
            List<GameObject> Golist = new List<GameObject>();
            List<GameObject> SupportTeams = BaseFunc.GetChilds(ObjectName);
            foreach (GameObject SupportObject in SupportTeams)
            {
                ISupport SupportObjectProperty = SupportObject.GetComponent<ISupport>();
                if (!SupportObjectProperty.IsWasSupport && SupportObjectProperty.SupportNode != null)
                {
                    AbstractNode NodeProperty = SupportObjectProperty.SupportNode.GetComponent<AbstractNode>();
                    int DefentCount = 0;
                    TeamList CurTeam = NodeProperty.CurTeam;
                    foreach (GameObject Team in CurTeam)
                    {
                        if (Team.GetComponent<AbstractTeam>().Camp == EnemyCamp)
                        {
                            DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                        }
                    }

                    if (SupportObjectProperty.FireSupport > DefentCount)
                    {
                        Golist.AddRange(CurTeam.Remove(EnemyCamp));
                    }
                    else
                    {
                        double dif = 0;
                        dif = SupportObjectProperty.FireSupport / (double)DefentCount;
                        foreach (GameObject Team in CurTeam)
                        {
                            Team.GetComponent<AbstractTeam>().BaseNumber = (int)(Team.GetComponent<AbstractTeam>().BaseNumber * (1 - dif));
                        }
                        //Golist.AddRange(CurTeam.Remove(CureCamp));
                    }
                }
                SupportObjectProperty.IsWasSupport = true;

            }
            foreach (GameObject go in Golist)
            {
                Destroy(go);
            }
        }

        public void RefreshOperation()
        {
            GameObject go = GameObject.FindGameObjectWithTag("Chess");
            if (go != null && go.transform.childCount != 0)
            {
                try
                {
                    go.BroadcastMessage("RefreshMe");
                }
                catch (Exception e)
                {
                    //Debug.Log(e.ToString());
                }
            }
            go = GameObject.Find("Turrets");
            if (go != null && go.transform.childCount != 0)
            {
                try
                {
                    go.BroadcastMessage("RefreshMe");
                }
                catch (Exception e)
                {
                    //Debug.Log(e.ToString());
                }
            }

            go = GameObject.Find("Enemys");
            if (go != null && go.transform.childCount != 0)
            {
                try
                {
                    go.BroadcastMessage("RefreshMe");
                }
                catch (Exception e)
                {
                    //Debug.Log(e.ToString());
                }
            }
        }

        
    }
}
