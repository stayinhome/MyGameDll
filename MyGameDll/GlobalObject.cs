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


        public  GameObject _CurSelectChess;

        public  GameObject _CurSelectNode;

        public  PanelType _CurPanel = PanelType.GamePanel;

        public  List<GameObject> listNode = new List<GameObject>();

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

        void Start()
        {
            MyEventManager.MyEventManager.Instance.AddListener(MyEventType.SelectNodeChange, SelectNode_Change);
            MyEventManager.MyEventManager.Instance.AddListener(MyEventType.SelectChessChange, SelectChess_Change);

        }

        private void SelectChess_Change(object render, EvenData evenData)
        {
            _CurSelectChess = evenData.gameObject;

        }

        private void SelectNode_Change(object render, EvenData evenData)
        {
            _CurSelectNode = evenData.gameObject;
        }
    }
}
