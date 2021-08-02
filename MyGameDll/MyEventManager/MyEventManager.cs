using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.MyEventManager
{
    public delegate void Event_Delegate(object render,EvenData evenData);


    public class MEventManager 
    {

        private static MEventManager _instance;
        public static MEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MEventManager();
                }
                return _instance;
            }
        }

        public Dictionary<MyEventType, Event_Delegate> Events = new Dictionary<MyEventType, Event_Delegate>();

        public void AddListener(MyEventType eventType , Event_Delegate event_Delegate)
        {
            if(!Events.ContainsKey(eventType))
            {
                Events.Add(eventType, event_Delegate);
            }
            else
            {
                Events[eventType] += event_Delegate;
            }

        }

        public void RemoveListener(MyEventType eventType)
        {
            if (Events.ContainsKey(eventType))
            {
                Events.Remove(eventType);
            }
        }

        public void RemoveListener(MyEventType eventType, Event_Delegate event_Delegate)
        {
            if (Events.ContainsKey(eventType))
            {
                Events[eventType] -= event_Delegate;
            }
        }

        public void DispatchEvent(MyEventType _eventType, object render, EvenData evenData)
        {
            if (!Events.ContainsKey(_eventType))
            {
                Debug.Log("Not Found Event:" + _eventType);
            }
            else
            {
                Events[_eventType](render, evenData);
            }
        }


    }


    public class EvenData
    {
        public GameObject gameObject;

        public object Value;

    }



    public enum MyEventType
    {
        SelectNodeChange = 1,

        SelectChessChange = 2,

        SelectChessOperaterValueChange = 3,

        MaterialCountValueChange = 4,

        OperationChange =5,
    }

}
