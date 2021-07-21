using MyGameDll.Model.Dto;
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
            TeamData team = new TeamData();
            team.Camp = CampEnum.Player;

            BaseFunc.CreatTeam(GlobalObject.CurSelectNode, team);

            GlobalObject.CurPanel = PanelType.GamePanel;

        }

    }
}
