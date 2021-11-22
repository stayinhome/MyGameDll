using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    public class ReBuildingButton : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob == this.gameObject)
                {

                    AbstractNode abstractNode = GlobalObject.CurSelectNode.GetComponent<AbstractNode>();
                    if(abstractNode != null)
                    {
                        GlobalObject.CurOperation = OperationType.TeamReBuilding;
                        GameObject TeamPanel = GameObject.Find("TeamCanvas").transform.Find("TeamPanel").gameObject;
                        if(TeamPanel != null)
                        {
                            TeamCreat teamCreat = TeamPanel.GetComponent<TeamCreat>();
                            List<GameObject> gameObjects = new List<GameObject>();
                            foreach(GameObject item in abstractNode.CurTeam)
                            {
                                if(item.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                                {
                                    gameObjects.Add(item);
                                }
                            }
                            if (gameObjects.Count > 0)
                            {
                                BaseFunc.SetCanvasButtonStateByName("TeamCanvas", "TeamPanel", true);
                                teamCreat.ReBulide(gameObjects);
                            }
                        }

                    }

                    BaseFunc.IniButtonState();

                }

            }

        }
    }
}