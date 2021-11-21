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
        public GameObject txtTeamType = null;
        public GameObject txtAttack = null;
        public GameObject txtDefent = null;
        public GameObject txtView = null;
        public GameObject txtOperater = null;
        public GameObject txtMaxMat = null;
        public GameObject txtNeedMat = null;

        public GameObject TempTeam = null;

        public GameObject Button = null;
        public int TeamIndex = 0;

        public bool IsReBulide = false;


        private Dictionary<int, GameObject> TeamContainer = new Dictionary<int, GameObject>();
        private List<GameObject> SelectRole = new List<GameObject>();
        private int NeedMat = 0;
        private TeamData team = new TeamData();

        public List<GameObject> TeamList = new List<GameObject>();
        public List<GameObject> RoleList = new List<GameObject>();

        public void Creat()
        {
            GlobalObject.CurOperation = OperationType.GamePanleControl;

            if (TeamList.Count <= 0)
            {
                return;
            }

            if (!IsReBulide)
            {
                if (GlobalObject.MaterialCount < NeedMat)
                {
                    Debug.Log("No Material");
                    return;
                }
            }


            foreach(GameObject item in TeamList)
            {
                AbstractTeam abstractTeam = item.GetComponent<AbstractTeam>();

                TeamData teamData = new TeamData();
                teamData.Camp = CampEnum.Player;
                teamData.Material = NeedMat;
                teamData.Member = abstractTeam.Member;
                //GlobalObject.MaterialCount -= NeedMat;


                TeamCreat.CreatTeam(GlobalObject.CurSelectNode, teamData);
            }


        }

        private TeamEnum GetTeamType(List<GameObject> SelectRole)
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

        public void AddRole(int RoleType)
        {
            #region 应废弃，改为按照角色选择
            RoleTypeEnum roleType = (RoleTypeEnum)RoleType;

            GameObject go = new GameObject();
            go.name = roleType.ToString();
            go.transform.parent = GameObject.Find("Roles").transform;
            AbstractRole role = go.AddComponent<AbstractRole>();
            role.RoleType = roleType;
            
            switch (roleType)
            {
                case RoleTypeEnum.Air:
                    {
                        role.Material = 0;
                        role.BaseValue = 5;
                        role.NeedMat = 4;
                        role.Name = "Air";
                        break;
                    }
                case RoleTypeEnum.Armor:
                    {
                        role.Material = 5;
                        role.BaseValue = 2;
                        role.NeedMat = 3;
                        role.Name = "Armor";

                        break;
                    }
                case RoleTypeEnum.Rifle:
                    {
                        role.Material = 2;
                        role.BaseValue = 2;
                        role.NeedMat = 2;
                        role.Name = "Rifle";


                        break;
                    }
                case RoleTypeEnum.Artillery:
                    {
                        role.Material = 0;
                        role.BaseValue = 4;
                        role.NeedMat = 4;
                        role.Name = "Artillery";


                        break;
                    }
                case RoleTypeEnum.Sniper:
                    {
                        role.Material = 0;
                        role.BaseValue = 3;
                        role.NeedMat = 2;
                        role.Name = "Sniper";


                        break;
                    }
                case RoleTypeEnum.Maneuver:
                    {
                        role.Material = 0;
                        role.BaseValue = 3;
                        role.NeedMat = 3;
                        role.Name = "Maneuver";

                        break;
                    }
            }

            #endregion

            if (this.TeamContainer.ContainsKey(TeamIndex))
            {
                Destroy(this.TeamContainer[TeamIndex]);
                this.TeamContainer[TeamIndex] = go;
            }
            else
            {
                this.TeamContainer.Add(TeamIndex, go);
            }
            if(Button != null)
            {
                Button.BroadcastMessage("SetUIText", role.Name);
            }
            CalTeamPanel();

        }

        public void AddRole(GameObject Role,int ContainerIndex)
        {
            AbstractRole role = Role.GetComponent<AbstractRole>();
            GameObject Button = GetTeamContainer(ContainerIndex);
            if (this.TeamContainer.ContainsKey(ContainerIndex))
            {
                this.TeamContainer[ContainerIndex] = Role;
            }
            else
            {
                this.TeamContainer.Add(ContainerIndex, Role);
            }
            if (Button != null)
            {
                Button.BroadcastMessage("SetUIText", role.Name);
            }
        }

        private GameObject GetTeamContainer(int containerIndex)
        {
            string containerName = "Container1";

            switch (containerIndex)
            {
                case 1:
                    {
                        containerName = "Container1";
                        break;
                    }
                case 2:
                    {
                        containerName = "Container2";
                        break;
                    }
                case 3:
                    {
                        containerName = "Container3";
                        break;
                    }
                case 4:
                    {
                        containerName = "Container4";
                        break;
                    }
                case 5:
                    {
                        containerName = "Container5";
                        break;
                    }
            }
            GameObject container = GameObject.Find("TeamCanvas").transform.Find("TeamPanel").Find("TeamContainer").Find(containerName).gameObject;
            return container;

        }

        public void SetButton(GameObject go)
        {
            switch (go.name)
            {
                case "Container1":
                    {
                        this.TeamIndex = 1;
                        break;
                    }
                case "Container2":
                    {
                        this.TeamIndex = 2;
                        break;
                    }
                case "Container3":
                    {
                        this.TeamIndex = 3;
                        break;
                    }
                case "Container4":
                    {
                        this.TeamIndex = 4;
                        break;
                    }
                case "Container5":
                    {
                        this.TeamIndex = 5;
                        break;
                    }
            }
            Button = go;
        }

        void OnDisable()
        {
            TeamContainer = new Dictionary<int, GameObject>();
            Button = null;
        }

        private void CalTeamPanel()
        {
            AbstractTeam TeamProperty = null;
            this.SelectRole = new List<GameObject>();
            this.NeedMat = 0;
            foreach (var item in TeamContainer)
            {
                this.SelectRole.Add(item.Value);
                this.NeedMat += item.Value.GetComponent<AbstractRole>().NeedMat;
            }

            if (SelectRole.Count <= 0)
            {
                return;
            }

            this.team.Member = SelectRole;
            this.team.TeamType = GetTeamType(SelectRole);

            try
            {
                TeamProperty = TempTeam.GetComponent<AbstractTeam>();
                if(TeamProperty != null)
                {
                    Destroy(TeamProperty);
                }
            }
            catch(Exception ex)
            {
                Debug.Log(ex.ToString());
            }

            switch (team.TeamType)
            {
                case TeamEnum.Rifle:
                    {
                        TeamProperty = TempTeam.AddComponent<RifleTeam>();
                        break;
                    }
                case TeamEnum.Artillery:
                    {
                        TeamProperty = TempTeam.AddComponent<ArtilleryTeam>();
                        break;
                    }
                case TeamEnum.Maneuver:
                    {
                        TeamProperty = TempTeam.AddComponent<ManeuverTeam>();
                     break;
                    }
                case TeamEnum.Sniper:
                    {
                        TeamProperty = TempTeam.AddComponent<SniperTeam>();
                        break;
                    }
                case TeamEnum.Armor:
                    {
                        TeamProperty = TempTeam.AddComponent<ArmorTeam>();
                        break;
                    }
                case TeamEnum.Air:
                    {
                        TeamProperty = TempTeam.AddComponent<AirTeam>();
                        break;
                    }
                case TeamEnum.None:
                default:
                    {
                        TeamProperty = TempTeam.AddComponent<NormolTeam>();
                        break;
                    }

            }
            TeamProperty.DoInit(team);

            txtTeamType.SendMessage("SetUIText", string.Format("TeamType : {0}", team.TeamType.ToString()));
            txtAttack.SendMessage("SetUIText", string.Format("Attack : {0}", TeamProperty.Attack));
            txtDefent.SendMessage("SetUIText", string.Format("Defent : {0}", TeamProperty.Defent));
            txtView.SendMessage("SetUIText", string.Format("View : {0}", TeamProperty.View));
            txtOperater.SendMessage("SetUIText", string.Format("Operater : {0}", TeamProperty.BaseOperater));
            txtMaxMat.SendMessage("SetUIText", string.Format("MaxMat : {0}", TeamProperty.MaxMaterial));
            txtNeedMat.SendMessage("SetUIText", string.Format("NeedMat : {0}", NeedMat));


        }

        public static void CreatTeam(GameObject Node, TeamData TeamData)
        {
            GameObject layerPrefab = null;
            GameObject go = null;
            switch (TeamData.Camp)
            {
                case CampEnum.Player:
                    {
                        layerPrefab = Resources.Load("Prefab/ChessGun") as GameObject;
                        break;
                    }
                case CampEnum.Enemy:
                    {
                        layerPrefab = Resources.Load("Prefab/Enemey") as GameObject;
                        break;
                    }
            }

            switch (TeamData.TeamType)
            {
                case TeamEnum.Rifle:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("RifleTeams").transform, true);
                        go.AddComponent<RifleTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.RifleSpritePath);

                        break;
                    }
                case TeamEnum.Artillery:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("ArtilleryTeams").transform, true);
                        go.AddComponent<ArtilleryTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ArtillerySpritePath);
                        break;
                    }
                case TeamEnum.Maneuver:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("ManeuverTeams").transform, true);
                        go.AddComponent<ManeuverTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ManeuverSpritePath);

                        break;
                    }
                case TeamEnum.Sniper:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("SniperTeams").transform, true);
                        go.AddComponent<SniperTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.SniperSpritePath);

                        break;
                    }
                case TeamEnum.Armor:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("ArmorTeams").transform, true);
                        go.AddComponent<ArmorTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.ArmorSpritePath);

                        break;  
                    }
                case TeamEnum.Air:
                    {
                        go = Instantiate(layerPrefab, GameObject.Find("AirTeams").transform, true);
                        go.AddComponent<AirTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.AirSpritePath);

                        break;
                    }
                case TeamEnum.None:
                default:
                    {
                        if (TeamData.Camp != CampEnum.Enemy)
                        {
                            go = Instantiate(layerPrefab, GameObject.Find("NormalTeams").transform, true);

                        }
                        else
                        {
                            go = Instantiate(layerPrefab, GameObject.Find("Enemys").transform, true);
                            go.tag = "Enemy";
                            go.name = "Enemy";
                        }
                        go.AddComponent<NormolTeam>();
                        BaseFunc.ChangeSpriteOnResourcesByImage(go, ResourcesPath.NoneSpritePath);

                        break;
                    }

            }

            Vector3 newposition = new Vector3(Node.transform.position.x, Node.transform.position.y, -5);
            go.transform.position = newposition;
            go.GetComponent<AbstractTeam>().CurNode = Node;
            go.GetComponent<AbstractTeam>().TeamType = TeamData.TeamType;
            go.GetComponent<AbstractTeam>().Material = TeamData.Material;
            go.GetComponent<AbstractTeam>().DoInit(TeamData);
            Node.GetComponent<AbstractNode>().CurTeam.Add(go);

        }

        public void LoadTeam(GameObject Team)
        {
            IniPanel();

            this.TempTeam = Team;
            AbstractTeam abstractTeam = Team.GetComponent<AbstractTeam>();
            int i = 1;
            foreach(GameObject Role in abstractTeam.Member)
            {
                AddRole(Role,i);
                i++;
            }
            CalTeamPanel();
        }

        private void IniPanel()
        {
            this.TeamContainer = new Dictionary<int, GameObject>();
            Button = null;

            txtTeamType.SendMessage("SetUIText", string.Format("TeamType : {0}", "null"));
            txtAttack.SendMessage("SetUIText", string.Format("Attack : {0}", 0));
            txtDefent.SendMessage("SetUIText", string.Format("Defent : {0}", 0));
            txtView.SendMessage("SetUIText", string.Format("View : {0}", 0));
            txtOperater.SendMessage("SetUIText", string.Format("Operater : {0}", 0));
            txtMaxMat.SendMessage("SetUIText", string.Format("MaxMat : {0}", 0));
            txtNeedMat.SendMessage("SetUIText", string.Format("NeedMat : {0}", 0));

            for(int i = 1;i<=5; i++)
            {
                GameObject Button = GetTeamContainer(i);
                if (Button != null)
                {
                    Button.BroadcastMessage("SetUIText", "Null");
                }
            }


        }

        public void AddTeam()
        {
            GameObject ConTent = GameObject.Find("TeamList").transform.Find("Viewport").Find("Content").gameObject;
            if (ConTent != null)
            {
                GameObject layerPrefab = Resources.Load("Prefab/TeamButton") as GameObject;
                GameObject go = Instantiate(layerPrefab, ConTent.transform, true);

                if(go != null)
                {
                    if (TeamList.Count > 0)
                    {
                        GameObject Golast = TeamList[TeamList.Count - 1];
                        Vector3 NewLocaltion = new Vector3(Golast.transform.position.x, Golast.transform.position.y - 40, Golast.transform.position.z);
                        go.transform.position = NewLocaltion;
                    }

                    TeamButton teamButton = go.GetComponent<TeamButton>();
                    if(teamButton != null)
                    {
                        TeamList.Add(teamButton.TempTeam);
                    }
                }


            }


        }

        public void RemoveTeam()
        {
            if(TempTeam != null)
            {
                TeamList.Remove(TempTeam);

                GameObject go = TempTeam.transform.parent.gameObject;
                if(go != null)
                {
                    Destroy(go);
                }
            }

        }
    }
}
