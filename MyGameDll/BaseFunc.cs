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


        public static void ShowButton(GameObject go,string ButtonName)
        {

            Vector3 NewPosition = new Vector3(go.transform.position.x + 1, go.transform.position.y + 1, go.transform.position.z - 1);
            SetButtonStateByName(ButtonName, true, NewPosition);

        }

        public static void ShowButton(GameObject go, List<string> ButtonNames)
        {

            for(int i = 0;i< ButtonNames.Count;i++)
            {
                Vector3 NewPosition = new Vector3(go.transform.position.x + 1, go.transform.position.y + 1 - i, go.transform.position.z - 1);
                SetButtonStateByName(ButtonNames[i], true, NewPosition);
            }


        }


        public static GameObject GetObjectByClick()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector2.up, 1);
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

        public static void ChangeSpriteOnResourcesByImage(GameObject go ,string ImagePath)
        {
            Texture2D Tex = Resources.Load(ImagePath) as Texture2D;
            if(Tex == null)
            {
                Debug.Log("无法从"+ ImagePath+"读取图片");
            }
            else
            {
                SpriteRenderer spr = go.GetComponent<SpriteRenderer>();
                Sprite sprite = Sprite.Create(Tex, new Rect(0, 0, Tex.width, Tex.height), new Vector2(0.5f, 0.5f));
                go.GetComponent<SpriteRenderer>().sprite = sprite;
            }

        }

        public static void ChangeSpriteOnResourcesBySprite(GameObject go, string SpritePath)
        {
            Sprite sprite = Resources.Load<Sprite>(SpritePath);
            go.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public static void IniButtonState()
        {
            BaseFunc.SetButtonStateByName(ButtonType.Deploy, false);
            BaseFunc.SetButtonStateByName(ButtonType.DeployArtillery, false);
            BaseFunc.SetButtonStateByName(ButtonType.FireSupport, false);
        }

        public static List<GameObject> GetChilds(GameObject go)
        {
            return GetChilds(go.name);
        }

        public static List<GameObject> GetChilds(string GameObjectName)
        {
            List<GameObject> ans = new List<GameObject>();
            GameObject go = GameObject.Find(GameObjectName);
            if(go!= null)
            {
                foreach(Transform item in go.transform)
                {
                    ans.Add(item.gameObject);
                }
            }


            return ans;
        }

        /// <summary>
        /// 获取空结点
        /// </summary>
        /// <param name="Number">数量</param>
        /// <param name="isAll">是否拿满</param>
        /// <returns></returns>
        public static HashSet<GameObject> GetNullNodeList(int Number,bool isGetAll)
        {
            HashSet<GameObject> ans = new HashSet<GameObject>();
            int count = GameObject.Find("NullNodeLIst").transform.childCount;

            if (isGetAll)
            {
                int i = 0;
                while (i < Number)
                {
                    int index = UnityEngine.Random.Range(0, count);
                    GameObject go = GameObject.Find("NullNodeLIst").transform.GetChild(index).gameObject;
                    if (go.GetComponent<AbstractNode>().g_CurTeamCount == 0 && go.GetComponent<AbstractNode>().OtherObject == null)
                    {
                        ans.Add(go);
                        i++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Number; i++)
                {
                    int index = UnityEngine.Random.Range(0, count);
                    GameObject go = GameObject.Find("NullNodeLIst").transform.GetChild(index).gameObject;
                    if (go.GetComponent<AbstractNode>().g_CurTeamCount == 0 && go.GetComponent<AbstractNode>().OtherObject == null)
                    {
                        ans.Add(go);
                    }

                }
            }



            return ans;
        }
    }
}