using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.TeamBulidng
{
    public class RoleButton : MonoBehaviour
    {
        public GameObject Role = null;


        public void SelectRole()
        {
            GameObject TeamCanvas = GameObject.Find("TeamCanvas");
            GameObject TeamPanel = TeamCanvas.transform.Find("TeamPanel").gameObject;
            GameObject TeamSelect = TeamCanvas.transform.Find("TeamSelect").gameObject;

            if (TeamPanel != null)
            {
                TeamPanel.SendMessage("AddRole", Role);
            }
            TeamSelect.SetActive(false);

        }


    }
}
