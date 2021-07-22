using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;

namespace MyGameDll.Team
{
    public class RifleTeam : AbstractTeam
    {

        public override void RefreshMe()
        {
            base.RefreshMe();
            Operater = BaseOperater;
        }

        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            TeamType = TeamEnum.Rifle;
            BaseOperater = 2;
            BaseView = 2;
            BaseNumber = 2;
            foreach (AbstractRole item in teamData.Member)
            {
                if(item.RoleType == RoleTypeEnum.Artillery || item.RoleType == RoleTypeEnum.Air)
                {
                    BaseNumber += (int) (0.2 * item.BaseValue);
                }
                else 
                {
                    BaseNumber += item.BaseValue;
                }

                if (item.RoleType == RoleTypeEnum.Sniper)
                {
                    BaseView = 4;

                }
                else if(item.RoleType == RoleTypeEnum.Armor || item.RoleType == RoleTypeEnum.Artillery)
                {
                    BaseOperater = 1;
                }

                MaxMaterial += item.Material;
            }

        }

    }
}
