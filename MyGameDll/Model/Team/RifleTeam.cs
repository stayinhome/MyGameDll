using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class RifleTeam : SupportTeam
    {

        public override void DoInit(TeamData teamData)
        {
            base.DoInit(teamData);
            BaseOperater = 2;
            BaseView = 2;
            MaxSupportRang = 5;
            foreach (GameObject item in teamData.Member)
            {
                AbstractRole role = item.GetComponent<AbstractRole>();
                MaxMaterial += role.Material;
            }

        }

        protected override int CalMaxSupportRang()
        {
            int ans = _MaxSupportRang;
            if (CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.HighPoints)
            {
                ans += PropertyValue.HighPointsAddRang / 2;
            }
            return ans;
        }



    }
}
