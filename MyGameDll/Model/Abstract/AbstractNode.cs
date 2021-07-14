using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Abstract
{
    public class AbstractNode : MonoBehaviour
    {

        public int NodeID = 0;

        /// <summary>
        /// 类型
        /// </summary>
        public NodeEnum NodeType { get; set; } = NodeEnum.Normol;

        /// <summary>
        /// 临接节点
        /// </summary>
        public List<GameObject> NextNode = new List<GameObject>();


        /// <summary>
        /// 当前存在队伍
        /// </summary>
        public TeamList CurTeam = new TeamList();


        void Start()
        {
            CurTeam.addTeam_Event += AddTeam_Event;
            CurTeam.removeTeam_Event += RemoveTeam_Event;
        }

        private void AddTeam_Event()
        {
            GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode.Add(gameObject);
        }

        private void RemoveTeam_Event()
        {
            GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode.Remove(gameObject);
        }

        /// <summary>
        /// 是否是临接节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsNextNode(GameObject node)
        {
            if(node!= null)
            {
                foreach (GameObject item in NextNode)
                {
                    if (item == node)
                    {
                        return true;
                    }
                }
            }


            return false;
        }


    }
}
