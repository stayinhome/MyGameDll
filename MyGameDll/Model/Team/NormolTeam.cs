using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class NormolTeam : AbstractTeam
    {

        public override void DoInit(TeamData teamData)
        {
            Camp = teamData.Camp;
            Member = teamData.Member;
            BaseOperater = 2;
            BaseView = 2;
            BaseNumber = 2;
            foreach (GameObject item in teamData.Member)
            {
                AbstractRole role = item.GetComponent<AbstractRole>();
                if (role.RoleType == RoleTypeEnum.Artillery || role.RoleType == RoleTypeEnum.Air)
                {
                    BaseNumber += (int)(0.2 * role.BaseValue);
                }              
                else
                {
                    BaseNumber += role.BaseValue;
                }

                if (role.RoleType == RoleTypeEnum.Sniper)
                {
                    BaseView = 4;

                }
                else if (role.RoleType == RoleTypeEnum.Armor || role.RoleType == RoleTypeEnum.Artillery)
                {
                    BaseOperater = 1;
                }

                MaxMaterial += role.Material;
            }

        }


    }
}