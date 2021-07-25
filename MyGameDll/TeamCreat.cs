using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using MyGameDll.Model.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class TeamCreat : MonoBehaviour
    {
        public List<GameObject> SelectRole = new List<GameObject>();

        public GameObject Button = null;

        public Dictionary<int, GameObject> TeamContainer = new Dictionary<int, GameObject>();

        public string ButtonText = "";

        public int TeamIndex = 0;

        public void Creat()
        {

            foreach(var item in TeamContainer)
            {
                SelectRole.Add(item.Value);
            }

            if(SelectRole.Count <= 0)
            {
                return;
            }

            TeamData team = new TeamData();
            team.Camp = CampEnum.Player;
            team.Member = SelectRole;
            team.TeamType = GetTeamType();

            TeamCreat.CreatTeam(GlobalObject.CurSelectNode, team);
            GlobalObject.CurOperation = OperationType.GamePanleControl;

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

            if (Rifle == SelectRole.Count)
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

        public void AddTeam(int RoleType)
        {
            RoleTypeEnum roleType = (RoleTypeEnum)RoleType;

            GameObject go = new GameObject();
            go.name = GetRoleName(roleType);
            go.transform.parent = GameObject.Find("Roles").transform;
            go.AddComponent<AbstractRole>();
            AbstractRole role = go.GetComponent<AbstractRole>();
            role.RoleType = roleType;
            switch (roleType)
            {
                case RoleTypeEnum.Air:
                    {
                        role.Material = 0;
                        role.BaseValue = 5;
                        ButtonText = "Air";
                        break;
                    }
                case RoleTypeEnum.Armor:
                    {
                        role.Material = 5;
                        role.BaseValue = 2;
                        ButtonText = "Armor";

                        break;
                    }
                case RoleTypeEnum.Rifle:
                    {
                        role.Material = 2;
                        role.BaseValue = 2;
                        ButtonText = "Rifle";

                        break;
                    }
                case RoleTypeEnum.Artillery:
                    {
                        role.Material = 0;
                        role.BaseValue = 4;
                        ButtonText = "Artillery";

                        break;
                    }
                case RoleTypeEnum.Sniper:
                    {
                        role.Material = 0;
                        role.BaseValue = 3;
                        ButtonText = "Sniper";

                        break;
                    }
                case RoleTypeEnum.Maneuver:
                    {
                        role.Material = 0;
                        role.BaseValue = 3;
                        ButtonText = "Maneuver";

                        break;
                    }
            }

            if (TeamContainer.ContainsKey(TeamIndex))
            {
                Destroy(TeamContainer[TeamIndex]);
                TeamContainer[TeamIndex] = go;
            }
            else
            {
                TeamContainer.Add(TeamIndex, go);
            }
            if(Button != null)
            {
                Button.BroadcastMessage("SetButtonText", ButtonText);
            }

        }

        private string GetRoleName(RoleTypeEnum roleType)
        {
            string name = "Normal";
            switch (roleType)
            {
                case RoleTypeEnum.Air:
                    {
                        name = "Air";
                        break;
                    }
                case RoleTypeEnum.Armor:
                    {
                        name = "Armor";
                        break;
                    }
                case RoleTypeEnum.Rifle:
                    {
                        name = "Rifle";
                        break;
                    }
                case RoleTypeEnum.Artillery:
                    {
                        name = "Artillery";
                        break;
                    }
                case RoleTypeEnum.Sniper:
                    {
                        name = "Sniper";
                        break;
                    }
                case RoleTypeEnum.Maneuver:
                    {
                        name = "Maneuver";
                        break;
                    }
            }
            return name;
        }


        public void SetButton(GameObject go)
        {
            switch (go.name)
            {
                case "Container1":
                    {
                        TeamIndex = 1;
                        break;
                    }
                case "Container2":
                    {
                        TeamIndex = 2;
                        break;
                    }
                case "Container3":
                    {
                        TeamIndex = 3;
                        break;
                    }
                case "Container4":
                    {
                        TeamIndex = 4;
                        break;
                    }
                case "Container5":
                    {
                        TeamIndex = 5;
                        break;
                    }
            }
            Button = go;
        }

        void OnDisable()
        {
            SelectRole = new List<GameObject>();
            TeamContainer = new Dictionary<int, GameObject>();
            ButtonText = "";
            Button = null;
        }


        public static void CreatTeam(GameObject Node, TeamData TeamData)
        {
            GameObject layerPrefab = null;
            GameObject go = null;
            //go = Instantiate(layerPrefab, GameObject.Find("Chess").transform, true);

            switch (TeamData.Camp)
            {
                case CampEnum.Player:
                    {
                        layerPrefab = Resources.Load("Prefab/ChessGun") as GameObject;
                        go = Instantiate(layerPrefab, GameObject.Find("Chess").transform, true);
                        break;
                    }
                case CampEnum.Enemy:
                    {
                        layerPrefab = Resources.Load("Prefab/Enemey") as GameObject;
                        go = Instantiate(layerPrefab, GameObject.Find("Enemys").transform, true);
                        go.tag = "Enemy";
                        go.name = "Enemy";
                        break;
                    }
            }
            //go.GetComponent<SpriteRenderer>().sprite
            if (go != null)
            {
                Vector3 newposition = new Vector3(Node.transform.position.x, Node.transform.position.y, -5);
                go.transform.position = newposition;
                switch (TeamData.TeamType)
                {
                    case TeamEnum.Rifle:
                        {
                            go.AddComponent<RifleTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.RifleSpritePath);
                            break;
                        }
                    case TeamEnum.Artillery:
                        {
                            go.AddComponent<ArtilleryTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ArtillerySpritePath);

                            break;
                        }
                    case TeamEnum.Maneuver:
                        {
                            go.AddComponent<ManeuverTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ManeuverSpritePath);

                            break;
                        }
                    case TeamEnum.Sniper:
                        {
                            go.AddComponent<SniperTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.SniperSpritePath);

                            break;
                        }
                    case TeamEnum.Armor:
                        {
                            go.AddComponent<ArmorTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ArmorSpritePath);

                            break;
                        }
                    case TeamEnum.Air:
                        {
                            go.AddComponent<AirTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.AirSpritePath);

                            break;
                        }
                    case TeamEnum.None:
                    default:
                        {
                            go.AddComponent<NormolTeam>();
                            BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.NoneSpritePath);

                            break;
                        }

                }
                go.GetComponent<AbstractTeam>().TeamType = TeamData.TeamType;
                go.GetComponent<AbstractTeam>().CurNode = Node;
                if (TeamData != null)
                {
                    go.GetComponent<AbstractTeam>().DoInit(TeamData);
                }
                Node.GetComponent<AbstractNode>().CurTeam.Add(go);
            }


        }


    }
}
