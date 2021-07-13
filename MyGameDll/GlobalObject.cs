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
        public static PanelType CurPanel
        {
            get
            {
                return GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurPanel;
            }
            set
            {
                GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurPanel = value;
            }
        }

        public static GameObject CurSelectChess
        {
            get
            {
                return GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurSelectChess;
            }
            set
            {
                GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurSelectChess = value;
            }
        }

        public static GameObject CurSelectNode
        {
            get
            {
                return GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurSelectNode;
            }
            set
            {
                GameObject.Find("GlobalObject").GetComponent<GlobalObject>()._CurSelectNode = value;
            }
        }

        public  GameObject _CurSelectChess;

        public  GameObject _CurSelectNode;

        public  PanelType _CurPanel = PanelType.GamePanel;

        public  List<AbstractNode> listNode = new List<AbstractNode>();

        void Start()
        {
            MyEventManager.MyEventManager.Instance.AddListener(MyEventType.SelectNodeChange, SelectNode_Change);
        }


        public void SelectNode_Change(GameObject go)
        {
            _CurSelectNode = go;
        }
    }
}
