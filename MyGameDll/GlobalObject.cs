using MyGameDll.Abstract;
using MyGameDll.MyEventManager;
using MyGameDll.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class GlobalObject : MonoBehaviour
    {
        public static RoundTypeEnum RoundType = RoundTypeEnum.Player;

        public static GameObject CurSelectObject;

        public static GameObject CurDoFireSupportObject;

        public  GameObject _CurSelectChess;

        public  GameObject _CurSelectNode;

        public static OperationType g_CurOperation = OperationType.GamePanleControl;

        public static OperationType CurOperation
        {
            get { return g_CurOperation; }

            set
            {
                g_CurOperation = value;
                EvenData evenData = new EvenData();
                evenData.Value = value;
                MEventManager.Instance.DispatchEvent(MyEventType.OperationChange, null, evenData);

            }
        }

        public static Dictionary<int, GameObject> Roles = new Dictionary<int, GameObject>();

        public static int _MaterialCount = 20;

        public static int MaterialCount
        {
            get
            {
                return _MaterialCount;
            }

            set
            {
                _MaterialCount = value;
                EvenData evenData = new EvenData();
                evenData.Value = value;
                MEventManager.Instance.DispatchEvent(MyEventType.MaterialCountValueChange, null, evenData);
            }
        }


        public  HashSet<GameObject> listNode = new HashSet<GameObject>();


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
            MEventManager.Instance.AddListener(MyEventType.SelectNodeChange, SelectNode_Change);
            MEventManager.Instance.AddListener(MyEventType.SelectChessChange, SelectChess_Change);
            LoadRole();
        }

        private void LoadRole()
        {
            GameObject RoleList = GameObject.Find("Roles");
            foreach(Transform child in RoleList.transform)
            {
                GameObject RoleGo = child.gameObject;
                AbstractRole RoleProperty = RoleGo.GetComponent<AbstractRole>();
                Roles.Add(RoleProperty.RoleID, RoleGo);

            }

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
