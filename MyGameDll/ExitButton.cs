using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class ExitButton : MonoBehaviour
    {
        public GameObject ob = null;

        public void DoExit()
        {
            GlobalObject.CurOperation = OperationType.GamePanleControl;

            ob.SetActive(false);
        }
    }
}
