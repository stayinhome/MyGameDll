using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    internal class BaseFunc
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

            Vector3 NewPosition = new Vector3(go.transform.position.x + 10, go.transform.position.y + 10, go.transform.position.z);
            SetButtonStateByTag(ButtonType, true, NewPosition);

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
            GameObject ButtenGo = GameObject.FindGameObjectWithTag(TagName);
            if (Active.HasValue)
            {
                ButtenGo.SetActive(Active.Value);
            }
            if (Position.HasValue)
            {
                ButtenGo.transform.position = Position.Value;
            }

        }


    }
}