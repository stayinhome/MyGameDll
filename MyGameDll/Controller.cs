using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameDll;
using System;
using MyGameDll.Abstract;
using MyGameDll.MyEventManager;
using MyGameDll.Model.Team;

public class Controller : MonoBehaviour
{

    private GameObject _SelectNode;
    public GameObject SelectNode
    {
        get { return _SelectNode; }
        set
        {
            _SelectNode = value;
            EvenData evenData = new EvenData();
            evenData.gameObject = value;
            MEventManager.Instance.DispatchEvent(MyEventType.SelectNodeChange,gameObject, evenData);
        }
    }

    private GameObject _SelectChess;
    public GameObject SelectChess
    {
        get { return _SelectChess; }
        set
        {
            _SelectChess = value;
            EvenData evenData = new EvenData();
            evenData.gameObject = value;
            MEventManager.Instance.DispatchEvent(MyEventType.SelectChessChange, gameObject, evenData);
        }
    }

    public bool HaveSelectChess
    {
        get
        {
            return _SelectChess != null;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GlobalObject.CurOperation == OperationType.GamePanleControl)
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob != null)
                {
                    Layer layer = (Layer)ob.layer;
                    switch (layer)
                    {
                        case Layer.Chess:
                            {
                                switch (ob.tag)
                                {
                                    case "Chess":
                                        {
                                            SelectChess = ob;
                                            SelectNode = ob.GetComponent<AbstractTeam>().CurNode;
                                            ShowButtonBySelectTeam(ob);
                                            break;
                                        }
                                    case "Enemy":
                                        {
                                            if (HaveSelectChess)
                                            {
                                                GameObject EnemyCurNode = ob.GetComponent<AbstractTeam>().CurNode;
                                                SelectNode = EnemyCurNode;
                                                SelectChess.GetComponent<AbstractTeam>().DoMoveTo(SelectNode);

                                            }

                                            break;
                                        }
                                }

                                break;

                            }
                        case Layer.Node:
                            {
                                switch (ob.tag)
                                {
                                    case "Commander":
                                    case "NullNode":
                                        {
                                            SelectNode = ob;
                                            //DoMove
                                            if (HaveSelectChess)
                                            {
                                                SelectChess.GetComponent<AbstractTeam>().DoMoveTo(SelectNode);

                                            }
                                            else if (!HaveSelectChess)
                                            {
                                                if (ob.tag == NodeType.Commander)
                                                {
                                                    BaseFunc.ShowButton(ob, ButtonType.Deploy);

                                                }

                                            }
                                            break;
                                        }
                                }
                                break;
                            }

                    }


                    SetButtonState();

                }
                else
                {
                    SelectNode = null;
                    SelectChess = null;
                    SetButtonState();
                }
            }else if(GlobalObject.CurOperation == OperationType.FireSupport)
            {

            }



        }

    }


    private void SetButtonState()
    {
        if(SelectNode == null)
        {
            BaseFunc.SetButtonStateByEnum(ButtonEnum.Deploy, false);

        }
        else
        {
            if (SelectNode.tag != NodeType.Commander)
            {
                BaseFunc.SetButtonStateByEnum(ButtonEnum.Deploy, false);
            }
        }


    }

    private void ShowButtonBySelectTeam(GameObject Team)
    {
        AbstractTeam TeamProperty = Team.GetComponent<AbstractTeam>();
        if(TeamProperty.Camp == CampEnum.Player)
        {
            List<string> ButtonList = new List<string>();
            switch (TeamProperty.TeamType)
            {
                case TeamEnum.Artillery:
                    {
                        ArtilleryTeam ArtilleryProperty = TeamProperty as ArtilleryTeam;
                        if (ArtilleryProperty.IsDeploy)
                        {
                            ButtonList.Add(ButtonType.DeployArtillery);
                            ButtonList.Add(ButtonType.FireSupport);
                        }
                        else
                        {
                            ButtonList.Add(ButtonType.DeployArtillery);
                        }
                        break;
                    }
            }


            BaseFunc.ShowButton(Team, ButtonList);
        }

    }

}
