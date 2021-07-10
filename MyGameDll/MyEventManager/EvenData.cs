using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.MyEventManager
{
    public class EvenData
    {
        public MyEventType EventType;
    }

    public class SelectNodeChangeEventData
    {
        public MyEventType EventType = MyEventType.SelectNodeChange;
        public SelectNode_Change callback;
    }
}
