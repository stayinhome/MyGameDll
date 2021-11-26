using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.TeamBulidng
{
    public class RoleButton : MonoBehaviour
    {
        public GameObject Role = new GameObject();


        public void SelectRole()
        {
            GameObject TeamPanel = GameObject.Find("TeamCanvas").transform.Find("TeamPanel").gameObject;
            if (TeamPanel != null)
            {
                TeamPanel.SendMessage("AddRole", Role);
            }
        }


    }
}
