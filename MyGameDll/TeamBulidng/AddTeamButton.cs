using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.TeamBulidng
{
    public class AddTeamButton: MonoBehaviour
    {
        public void AddTeam()
        {
            GameObject ConTent = GameObject.Find("TeamList")?.transform.Find("Content")?.gameObject;
            if(ConTent != null)
            {

            }


        }


    }
}
