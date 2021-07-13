using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    class TeamCreat : MonoBehaviour
    {
        public void Creat()
        {
            BaseFunc.CreatTeam(GlobalObject.CurSelectNode);

            GameObject.Find("TeamPanel").SetActive(false);
        }

    }
}
