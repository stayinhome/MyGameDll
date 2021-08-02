
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class SniperTeam :SupportTeam
    {
        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 2;
            BaseView = 4;
            MaxSupportRang = 20;


        }
        protected override int CalView()
        {
            int view = base.CalView();
            if (CurNode != null && CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.HighPoints)
            {
                view += PropertyValue.HighPointsAddView * 2;
            }

            return view;
        }

        protected override int CalMaxSupportRang()
        {
            int ans = _MaxSupportRang;
            if (CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.HighPoints)
            {
                ans += PropertyValue.HighPointsAddRang;
            }
            return ans;
        }

        protected override int CalFireSupport()
        {
            return (int)(CalAttack() * PropertyValue.SniperSupportCorrection);
        }

        protected override int CalDefent()
        {
            return (int)(base.CalDefent() * PropertyValue.SniperDefentCorrection);
        }
    }
}