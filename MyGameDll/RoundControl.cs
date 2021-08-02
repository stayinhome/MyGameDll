using MyGameDll.Abstract;
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

                Battle(RoundTypeEnum.Enemy);

                CreatMaterials();

                RefreshOperation();

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

            List<GameObject> list =  GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode;

            List<GameObject> Golist = new List<GameObject>();

            CampEnum CureCamp = CampEnum.None;
            CampEnum OtherCamp = CampEnum.None;


            if (RoundType == RoundTypeEnum.Player)
            {
                CureCamp = CampEnum.Player;
                OtherCamp = CampEnum.Enemy;
            }
            else if (RoundType == RoundTypeEnum.Enemy)
            {
                CureCamp = CampEnum.Enemy;
                OtherCamp = CampEnum.Player;

            }

            #region 普通战斗
            while (list.Count>0)
            {
                GameObject Node = list[0];
                int AttackCount = 0;
                int DefentCount = 0;
                TeamList CurTeam = Node.GetComponent<AbstractNode>().CurTeam;
                List<GameObject> FireSupport = Node.GetComponent<AbstractNode>().FireSupport;


                foreach (GameObject Team in CurTeam)
                {
                    if (Team.GetComponent<AbstractTeam>().Camp == CureCamp)
                    {
                        AttackCount += Team.GetComponent<AbstractTeam>().Attack;
                    }
                    else if (Team.GetComponent<AbstractTeam>().Camp == OtherCamp)
                    {
                        DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                    }

                }
                foreach (GameObject Team in FireSupport)
                {
                    SupportTeam supportTeam = Team.GetComponent<SupportTeam>();
                    if (supportTeam != null)
                    {
                        if (supportTeam.Camp == CureCamp)
                        {
                            AttackCount += supportTeam.FireSupport;
                        }
                        else if (supportTeam.Camp == OtherCamp)
                        {
                            DefentCount += supportTeam.FireSupport;
                        }
                        supportTeam.IsWasSupport = true;

                    }

                }

                if (AttackCount > DefentCount)
                {
                    Golist.AddRange(CurTeam.Remove(OtherCamp));
                }
                else
                {
                    Golist.AddRange(CurTeam.Remove(CureCamp));
                }


            }
            foreach(GameObject go in Golist)
            {
                Destroy(go);
            }
            #endregion

            #region 支援战斗
            DoSupport("SniperTeams", OtherCamp);
            DoSupport("AirTeams", OtherCamp);
            DoSupport("ArtilleryTeams", OtherCamp);
            #endregion



        }

        private void DoSupport(string ObjectName, CampEnum OtherCamp)
        {
            List<GameObject> Golist = new List<GameObject>();
            List<GameObject> SupportTeams = BaseFunc.GetChilds(ObjectName);
            foreach (GameObject Sniper in SupportTeams)
            {
                SupportTeam SupportTeam = Sniper.GetComponent<SupportTeam>();
                if (!SupportTeam.IsWasSupport && SupportTeam.SupportNode != null)
                {
                    AbstractNode NodeProperty = SupportTeam.SupportNode.GetComponent<AbstractNode>();
                    int DefentCount = 0;
                    TeamList CurTeam = NodeProperty.CurTeam;
                    foreach (GameObject Team in CurTeam)
                    {
                        if (Team.GetComponent<AbstractTeam>().Camp == OtherCamp)
                        {
                            DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                        }
                    }

                    if (SupportTeam.FireSupport > DefentCount)
                    {
                        Golist.AddRange(CurTeam.Remove(OtherCamp));
                    }
                    else
                    {
                        //Golist.AddRange(CurTeam.Remove(CureCamp));
                    }
                }
                SupportTeam.IsWasSupport = true;

            }
            foreach (GameObject go in Golist)
            {
                Destroy(go);
            }
        }

        public void RefreshOperation()
        {
            GameObject go = GameObject.FindGameObjectWithTag("Chess");
            if (go != null)
            {
                try
                {
                    go.BroadcastMessage("RefreshMe");
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }
        }

        
    }
}
