using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using UnityEngine;

namespace MyGameDll.Team
{
    public class ArtilleryTeam : SupportTeam
    {
        /// <summary>
        /// 是否部署
        /// </summary>
        public bool IsDevelopment = false;


        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            TeamType = TeamEnum.Artillery;
            BaseOperater = 1;
            BaseView = 2;
            foreach (AbstractRole item in teamData.Member)
            {
                BaseNumber += item.BaseValue;
            }
            MinSupportRang = 3;
            MaxSupportRang = 8;
            FireSupport = BaseNumber * 2;
        }

        public override bool CanMoveTo(GameObject Node)
        {
            if (IsDevelopment)
            {
                return false;
            }
            return base.CanMoveTo(Node);
        }

        protected override int CalAttack()
        {
            return 0;
        }

        protected override int CalDefent()
        {
            return (int)(BaseNumber * 0.5);
        }

    }
}
