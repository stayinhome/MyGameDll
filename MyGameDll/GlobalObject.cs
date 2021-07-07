using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class GlobalObject : MonoBehaviour
    {
        public GameObject SelectChess;

        public GameObject SelectNode;

        public List<AbstractNode> listNode = new List<AbstractNode>();


    }
}
