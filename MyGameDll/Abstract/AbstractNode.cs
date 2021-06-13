using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Abstract
{
    class AbstractNode : MonoBehaviour
    {

        /// <summary>
        /// 类型
        /// </summary>
        public NodeEnum ChessType { get; set; } = NodeEnum.Normol;

        /// <summary>
        /// 攻击力
        /// </summary>
        public List<AbstractNode> NextNode = new List<AbstractNode>();



    }
}
