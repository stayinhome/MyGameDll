using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class ArtilleryTeam : SupportTeam
    {
        /// <summary>
        /// 是否部署
        /// </summary>
        public bool IsDeploy = false;

        public bool DoDeploy = false;


        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 1;
            BaseView = 2;
            MinSupportRang = 15;
            MaxSupportRang = 30;
        }

        public override bool CanMoveTo(GameObject Node)
        {
            if (IsDeploy || DoDeploy)
            {
                return false;
            }
            return base.CanMoveTo(Node);
        }

        protected override int CalAttack()
        {
            return (int)(base.CalAttack() * PropertyValue.ArtilleryAttackCorrection);
        }

        protected override int CalDefent()
        {
            return (int)(base.CalDefent() * PropertyValue.ArtilleryDefentCorrection);
        }

        protected override int CalMaxSupportRang()
        {
            int ans = _MaxSupportRang;
            if(CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.ArtilleryPosition)
            {
                ans += PropertyValue.ArtilleryPositionAddRang;
            }
            if (CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.HighPoints)
            {
                ans += PropertyValue.HighPointsAddRang;
            }

            return ans;
        }

        protected override int CalFireSupport()
        {
            return (int)(BaseNumber * PropertyValue.ArtillerySupportCorrection);
        }

        public override void RefreshMe()
        {
            base.RefreshMe();
            if (DoDeploy)
            {
                IsDeploy = !IsDeploy;
                DoDeploy = false;
            }
        }

    }
}
