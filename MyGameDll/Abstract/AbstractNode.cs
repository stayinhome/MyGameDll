using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Abstract
{
    public class AbstractNode : MonoBehaviour
    {

        /// <summary>
        /// 类型
        /// </summary>
        public NodeEnum NodeType { get; set; } = NodeEnum.Normol;

        /// <summary>
        /// 临接节点
        /// </summary>
        public List<GameObject> NextNode = new List<GameObject>();

        /// <summary>
        /// 是否是临接节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsNextNode(GameObject node)
        {
            foreach(GameObject item in NextNode)
            {
                if(item == node)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
