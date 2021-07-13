using MyGameDll.Abstract;
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


        public static void ShowButton(GameObject go,ButtonEnum Type)
        {
            string ButtonType = "None";
            switch (Type)
            {
                case ButtonEnum.Development:
                    ButtonType = "Development";
                    break;
            }

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

        public static void CreatTeam(GameObject Node , AbstractTeam TeamData = null)
        {
            GameObject layerPrefab = Resources.Load("Prefab/ChessGun") as GameObject;
            GameObject go = Instantiate(layerPrefab, GameObject.Find("Chess").transform, true);
            go.transform.localPosition = Node.transform.localPosition;
            go.GetComponent<AbstractTeam>().CurNode = Node;
        }


    }
}