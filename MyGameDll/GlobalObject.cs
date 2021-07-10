using MyGameDll.Abstract;
using MyGameDll.MyEventManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class GlobalObject : MonoBehaviour
    {
        public GameObject CurSelectChess;

        public GameObject CurSelectNode;

        public List<AbstractNode> listNode = new List<AbstractNode>();

        void Start()
        {
            MyEventManager.MyEventManager.Instance.AddListener(MyEventType.SelectNodeChange, SelectNode_Change);
        }


        public void SelectNode_Change(GameObject go)
        {
            CurSelectNode = go;
        }
    }
}
