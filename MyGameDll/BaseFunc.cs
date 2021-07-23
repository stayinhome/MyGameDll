using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using MyGameDll.Model.Team;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    internal class BaseFunc : MonoBehaviour
    {


        public static void ShowButton(GameObject go,string ButtonType)
        {

            Vector3 NewPosition = new Vector3(go.transform.position.x + 1, go.transform.position.y + 1, go.transform.position.z);
            SetButtonStateByName(ButtonType, true, NewPosition);

        }

        public static GameObject GetObjectByClick()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.up, 100);
            if (hit.collider != null)
            {
                GameObject ob = hit.collider.gameObject;

                return ob;

            }
            else
            {
                return null;
            }
        }

        public static void SetButtonStateByTag(string TagName,bool? Active = null,Vector3? Position = null)
        {
            GameObject Button = GameObject.FindGameObjectWithTag(TagName);


        }

        public static void SetButtonStateByEnum(ButtonEnum ButtonEnum, bool? Active = null, Vector3? Position = null)
        {
            string ButtonName = "";
            switch (ButtonEnum)
            {
                case ButtonEnum.Development:
                    {
                        ButtonName = ButtonType.Development;
                        break;
                    }
                case ButtonEnum.Building:
                    {
                        ButtonName = ButtonType.Building;
                        break;
                    }

            }
            if(ButtonName != "")
            {
                SetButtonStateByName(ButtonName, Active, Position);
            }

        }

        public static void SetButtonStateByName(string ButtonName, bool? Active = null, Vector3? Position = null)
        {
            GameObject ButtonList = GameObject.Find("ButtonList");
            if(ButtonList != null)
            {
                GameObject Buttengo = ButtonList.transform.Find(ButtonName).gameObject;
                if (Buttengo != null)
                {
                    if (Active.HasValue)
                    {
                        Buttengo.SetActive(Active.Value);
                    }
                    if (Position.HasValue)
                    {
                        Buttengo.transform.position = Position.Value;
                    }
                }
                else
                {
                    Debug.Log("Buttengo is null");
                }
            }

        }

        public static void SetCanvasButtonStateByName(string CanvasName,string ObjectName, bool? Active = null, Vector3? Position = null)
        {
            GameObject Canvas = GameObject.Find(CanvasName);
            if (Canvas != null)
            {
                GameObject Buttengo = Canvas.transform.Find(ObjectName).gameObject;
                if(Buttengo != null)
                {
                    if (Active.HasValue)
                    {
                        Buttengo.SetActive(Active.Value);
                    }
                    if (Position.HasValue)
                    {
                        Buttengo.transform.position = Position.Value;
                    }
                }
                else
                {
                    Debug.Log("Buttengo is null");
                }

            }
            else
            {
                Debug.Log("Buttengo is null");
            }
        }

        public static void CreatTeam(GameObject Node , TeamData TeamData)
        {
            GameObject layerPrefab = null;
            GameObject go = null;

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
                        go = Instantiate(layerPrefab, GameObject.Find("Enemeys").transform, true);
                        break;
                    }
            }

            if(go != null)
            {
                Vector3 newposition = new Vector3(Node.transform.position.x, Node.transform.position.y, -5);
                go.transform.position = newposition;
                switch (TeamData.TeamType)
                {
                    case TeamEnum.Rifle:
                        {
                            go.AddComponent<RifleTeam>();
                            break;
                        }
                    case TeamEnum.Artillery:
                        {
                            go.AddComponent<ArtilleryTeam>();
                            break;
                        }
                    case TeamEnum.None:
                    default:
                        {
                            go.AddComponent<NormolTeam>();
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

        public static bool SelectTeamCanMoveToNode(GameObject Team,GameObject Node)
        {
            if(Team.GetComponent<AbstractTeam>() == null)
            {
                return false;
            }

            if (Team.GetComponent<AbstractTeam>().Operater <= 0)
            {
                return false;
            }

            if (Team.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().CurTeam.HaveDifferentCamp())
            {
                return false;
            }

            if (! Node.GetComponent<AbstractNode>().IsNextNode(Team.GetComponent<AbstractTeam>().CurNode))
            {
                return false;
            }

            return true;
        }

        public static bool TeamMoveToNode(GameObject Team, GameObject Node)
        {
            if (!SelectTeamCanMoveToNode(Team, Node))
            {
                return false;
            }

            Team.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().CurTeam.Remove(Team);
            Team.GetComponent<AbstractTeam>().Operater--;
            Team.transform.position = new Vector3(Node.transform.position.x, Node.transform.position.y, Team.transform.position.z);
            Node.GetComponent<AbstractNode>().CurTeam.Add(Team);
            Team.GetComponent<AbstractTeam>().CurNode = Node;

            return true;


        }
    }
}