using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
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
                Battle();

                RefreshOperation();

                CreatEnemy();
            }

        }

        public void CreatEnemy()
        {
            int count = GameObject.Find("NullNodeLIst").transform.childCount;
            HashSet<GameObject> list = new HashSet<GameObject>();
            for(int i = 0;i<3;i++)
            {
                int index = UnityEngine.Random.Range(0, count);
                GameObject go = GameObject.Find("NullNodeLIst").transform.GetChild(index).gameObject;
                if (go.GetComponent<AbstractNode>().CurTeam.Count == 0)
                {
                    list.Add(go);

                }


            }

            foreach(GameObject item in list)
            {
                TeamData team = new TeamData();
                team.Camp = CampEnum.Enemy;
                team.BaseNumber = 2;
                team.BaseView = 2;

                TeamCreat.CreatTeam(item, team);
            }
            //List<GameObject> list = GameObject.Find("NullNodeLIst").transform.chi;
        }

        public void Battle()
        {

            List<GameObject> list =  GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode;

            List<GameObject> Golist = new List<GameObject>();

            while(list.Count>0)
            {
                GameObject Node = list[0];
                int AttackCount = 0;
                int DefentCount = 0;
                TeamList CurTeam = Node.GetComponent<AbstractNode>().CurTeam;

                if (GlobalObject.RoundType == RoundTypeEnum.Player)
                {
                    foreach(GameObject Team in CurTeam)
                    {
                        if (Team.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                        {
                            AttackCount += Team.GetComponent<AbstractTeam>().Attack;
                        }
                        else if(Team.GetComponent<AbstractTeam>().Camp == CampEnum.Enemy)
                        {
                            DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                        }
                    }
                    if(AttackCount > DefentCount)
                    {
                        Golist.AddRange(CurTeam.Remove(CampEnum.Enemy));
                    }
                    else
                    {
                        Golist.AddRange(CurTeam.Remove(CampEnum.Player));
                    }

                }
                else if (GlobalObject.RoundType == RoundTypeEnum.Enemy)
                {
                    foreach (GameObject Team in CurTeam)
                    {
                        if (Team.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                        {
                            DefentCount += Team.GetComponent<AbstractTeam>().Defent;
                        }
                        else if (Team.GetComponent<AbstractTeam>().Camp == CampEnum.Enemy)
                        {
                            AttackCount += Team.GetComponent<AbstractTeam>().Attack;
                        }
                    }
                    if (AttackCount > DefentCount)
                    {
                        Golist.AddRange(CurTeam.Remove(CampEnum.Player));
                    }
                    else
                    {
                        Golist.AddRange(CurTeam.Remove(CampEnum.Enemy));
                    }
                }

            }

            foreach(GameObject go in Golist)
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
