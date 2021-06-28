using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class RoundControl : MonoBehaviour
    {

        public void DoRefresh()
        {
            GameObject go = GameObject.FindGameObjectWithTag("Chess");
            if(go != null)
            {
                try
                {
                    go.BroadcastMessage("RefreshMe");
                }
                catch (Exception e)
                {
                    Debug.Log(e.ToString());
                }
            }
        }
    }
}
