using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.MyEventManager
{
    public delegate void SelectNode_Change(GameObject go = null);


    public class MyEventManager 
    {

        private static MyEventManager _instance;
        public static MyEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyEventManager();
                }
                return _instance;
            }
        }

        public List<SelectNodeChangeEventData> selectNodeChangeEvents = new List<SelectNodeChangeEventData>();

        public void AddListener(MyEventType eventType , SelectNode_Change selectNode_Change)
        {
            SelectNodeChangeEventData eventData = selectNodeChangeEvents.Find(p => p.EventType == eventType);
            if(eventData == null)
            {
                eventData = new SelectNodeChangeEventData();
                eventData.EventType = eventType;
                eventData.callback = selectNode_Change;
                selectNodeChangeEvents.Add(eventData);
            }
            else
            {
                eventData.callback += selectNode_Change;
            }

        }

        public void RemoveListener(MyEventType eventType, SelectNode_Change selectNode_Change)
        {
            SelectNodeChangeEventData eventData = selectNodeChangeEvents.Find(p => p.EventType == eventType);


            if (eventData != null)
            {
                eventData.callback -= selectNode_Change;
                if (eventData.callback == null)
                    selectNodeChangeEvents.Remove(eventData);
            }
        }

        public void DispatchEvent(MyEventType _eventType, GameObject _data = null)
        {
            SelectNodeChangeEventData eventData = selectNodeChangeEvents.Find(a => a.EventType == _eventType);
            if (eventData == null)
            {
                Debug.Log("Not Found Event:" + _eventType);
            }
            else
            {
                eventData.callback(_data);
            }
        }


    }



    public enum MyEventType
    {
        SelectNodeChange = 1,
    }

}
