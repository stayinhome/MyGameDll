using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.TeamBulidng
{
    public class RoleSelectPanel : MonoBehaviour
    {
        public HashSet<GameObject> RoleSet = new HashSet<GameObject>();

        void OnEnable()
        {
            RoleSet = new HashSet<GameObject>();
        }


        public void LoadRoleSet(HashSet<GameObject> RoleSet)
        {
            this.RoleSet = RoleSet;

            foreach(GameObject item in RoleSet)
            {
                CreatButton(item);
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

                }


            }
        }
    }
}
