using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.TeamBulidng
{
    public class RoleSelectPanel : MonoBehaviour
    {
        public Dictionary<int, GameObject> RoleSet = new Dictionary<int, GameObject>();

        public List<GameObject> ButtonList = new List<GameObject>();


        void OnEnable()
        {
            LoadRoleSet();
        }


        public void LoadRoleSet()
        {
            RoleSet = new Dictionary<int, GameObject>();

            GameObject RoleList = GameObject.Find("Roles");
            foreach (Transform child in RoleList.transform)
            {
                GameObject RoleGo = child.gameObject;
                AbstractRole RoleProperty = RoleGo.GetComponent<AbstractRole>();
                if (!RoleProperty.isDeploy)
                {
                    RoleSet.Add(RoleProperty.RoleID, RoleGo);
                    CreatButton(RoleGo);
                }


            }


        }

        private void CreatButton(GameObject Role)
        {
            GameObject ConTent = gameObject.transform.Find("Viewport").Find("Content").gameObject;
            if (ConTent != null)
            {
                GameObject layerPrefab = Resources.Load("Prefab/RoleButton") as GameObject;
                GameObject go = Instantiate(layerPrefab, ConTent.transform, true);

                if (go != null)
                {
                    Vector3 NewLocaltion = new Vector3(ConTent.transform.position.x, ConTent.transform.position.y - 40, ConTent.transform.position.z);
                    go.transform.position = NewLocaltion;
                    go.GetComponent<RoleButton>().Role = Role;
                    ButtonList.Add(go);
                }


            }
        }

        private void OnDisable()
        {
            foreach(GameObject bt in ButtonList)
            {
                bt.GetComponent<RoleButton>().Role = null;
                Destroy(bt);
            }
            ButtonList.Clear();
        }
    }
}
