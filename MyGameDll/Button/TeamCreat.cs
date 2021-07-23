using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    public class TeamCreat : MonoBehaviour
    {
        public List<GameObject> SelectRole = new List<GameObject>();




        public void Creat()
        {
            if(SelectRole.Count <= 0)
            {
                return;
            }

            TeamData team = new TeamData();
            team.Camp = CampEnum.Player;
            team.Member = SelectRole;
            team.TeamType = GetTeamType();

            BaseFunc.CreatTeam(GlobalObject.CurSelectNode, team);
            GlobalObject.CurPanel = PanelType.GamePanel;

        }

        private TeamEnum GetTeamType()
        {
            TeamEnum ans = TeamEnum.None;
            int Rifle = 0;
            int Armor = 0;
            int Artillery = 0;
            int Maneuver = 0;
            int Sniper = 0;
            int Air = 0;

            foreach (GameObject item in SelectRole)
            {
                AbstractRole role = item.GetComponent<AbstractRole>();
                switch (role.RoleType)
                {
                    case RoleTypeEnum.Rifle:
                        {
                            Rifle++;
                            break;
                        }
                    case RoleTypeEnum.Sniper:
                        {
                            Sniper++;
                            break;
                        }
                    case RoleTypeEnum.Air:
                        {
                            Air++;
                            break;
                        }
                    case RoleTypeEnum.Artillery:
                        {
                            Artillery++;
                            break;
                        }
                    case RoleTypeEnum.Armor:
                        {
                            Armor++;
                            break;
                        }
                    case RoleTypeEnum.Maneuver:
                        {
                            Maneuver++;
                            break;
                        }
                }
            }

            if(Rifle == SelectRole.Count)
            {
                ans = TeamEnum.Rifle;
            }
            else if (Armor == SelectRole.Count)
            {
                ans = TeamEnum.Armor;
            }
            else if (Artillery == SelectRole.Count)
            {
                ans = TeamEnum.Artillery;
            }
            else if (Maneuver == SelectRole.Count)
            {
                ans = TeamEnum.Maneuver;
            }
            else if (Sniper == SelectRole.Count)
            {
                ans = TeamEnum.Sniper;
            }
            else if (Air == SelectRole.Count)
            {
                ans = TeamEnum.Air;
            }

            return ans;
        }

    }
}
