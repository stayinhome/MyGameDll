using MyGameDll.Chess;
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
            team.Camp = CampEnum.friend;
            team.BaseNumber = 3;
            team.BaseOperater = 3;
            team.BaseView = 2;

            BaseFunc.CreatTeam(GlobalObject.CurSelectNode, team);

            //GameObject.Find("TeamPanel").SetActive(false);

            GlobalObject.CurPanel = PanelType.GamePanel;

        }

    }
}
