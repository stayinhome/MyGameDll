using MyGameDll.Chess;
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
            ChessGun team = new ChessGun();
            team.Camp = CampEnum.friend;

            BaseFunc.CreatTeam(GlobalObject.CurSelectNode, team);

            GameObject.Find("TeamPanel").SetActive(false);

            GlobalObject.CurPanel = PanelType.GamePanel;

        }

    }
}
