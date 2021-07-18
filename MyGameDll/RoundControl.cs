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
            //Battle();

            RefreshOperation();

            CreatEnemy();
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
                team.Camp = CampEnum.enemy;
                team.BaseNumber = 2;
                team.BaseView = 2;

                BaseFunc.CreatTeam(item, team);
            }
            //List<GameObject> list = GameObject.Find("NullNodeLIst").transform.chi;
        }

        public void Battle()
        {

            List<GameObject> list =  GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode;


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
