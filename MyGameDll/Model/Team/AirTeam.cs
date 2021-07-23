using MyGameDll.Model.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyGameDll.Model.Team
{
    public class AirTeam : SupportTeam
    {
        /// <summary>
        /// 是否部署
        /// </summary>
        public bool IsDevelopment = false;


        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 3;
            BaseView = 2;
            MinSupportRang = 0;
            MaxSupportRang = 12;
        }

        protected override int CalView()
        {
            int view = base.CalView();
            if (IsDevelopment)
            {
                view += 4;
            }
            return view;
        }

        protected override int CalAttack()
        {
            return (int)(base.CalAttack() * PropertyValue.AirAttackCorrection);
        }

        protected override int CalDefent()
        {
            return (int)(base.CalDefent() * PropertyValue.AirDefentCorrection);
        }

        protected override int CalFireSupport()
        {
            return (int)(BaseNumber * PropertyValue.AirSupportCorrection);
        }
    }
}