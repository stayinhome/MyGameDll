using MyGameDll.Abstract;
using MyGameDll.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class BuildingCreat : MonoBehaviour
    {
        public GameObject txtSelectType = null;

        public BuildEnum SelectType = BuildEnum.None;

        public GameObject SelectTeam = null;

        public void SetSelectType(int buildType)
        {

            SelectType = (BuildEnum)buildType;
            if (txtSelectType != null)
            {
                txtSelectType.SendMessage("SetUIText", "Select Type:" + SelectType.ToString());
            }
        }

        public void CreatBuilding()
        {
            GlobalObject.CurOperation = OperationType.GamePanleControl;

            AbstractTeam TeamProperty = SelectTeam.GetComponent<AbstractTeam>();
            CreatBuilding(TeamProperty.CurNode, SelectType, TeamProperty.Camp);

            this.gameObject.SetActive(false);

        }

        void OnDisable()
        {
            SelectType = BuildEnum.None;
            SelectTeam = null;
            //SetSelectType(0);
        }

        public static void CreatBuilding(GameObject Node, BuildEnum buildType,CampEnum Camp)
        {
            if(Node == null || buildType == BuildEnum.None)
            {
                return;
            }
            if(Node.GetComponent<AbstractNode>().OtherObject != null)
            {
                return;
            }

            GameObject layerPrefab = null;
            GameObject go = null;
            switch (buildType)
            {
                case BuildEnum.Roadblock:
                    {
                        layerPrefab = Resources.Load("Prefab/Building/Roadblock") as GameObject;
                        go = Instantiate(layerPrefab, GameObject.Find("Roadblocks").transform, true);
                        break;
                    }
                case BuildEnum.Trap:
                    {
                        layerPrefab = Resources.Load("Prefab/Building/Trap") as GameObject;
                        go = Instantiate(layerPrefab, GameObject.Find("Traps").transform, true);
                        break;
                    }
                case BuildEnum.Turret:
                    {
                        layerPrefab = Resources.Load("Prefab/Building/Turret") as GameObject;
                        go = Instantiate(layerPrefab, GameObject.Find("Turrets").transform, true);
                        break;
                    }
            }

            Vector3 newposition = new Vector3(Node.transform.position.x, Node.transform.position.y, -5);
            go.transform.position = newposition;
            go.GetComponent<AbstractBuilding>().Camp = Camp;
            Node.GetComponent<AbstractNode>().OtherObject = go;

        }


    }
}
