using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameDll;
using System;
using MyGameDll.Abstract;
using MyGameDll.MyEventManager;

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
            if(GlobalObject.CurPanel == PanelType.GamePanel)
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob != null)
                {

                    switch (ob.tag)
                    {
                        case "Chess":
                            {
                                SelectChess = ob;
                                break;
                            }
                        case "Enemy":
                            {
                                if (HaveSelectChess)
                                {
                                    GameObject EnemyCurNode = ob.GetComponent<AbstractTeam>().CurNode;
                                    SelectNode = EnemyCurNode;
                                    BaseFunc.TeamMoveToNode(SelectChess, EnemyCurNode);                           

                                }

                                break;
                            }
                        case "Commander":
                        case "NullNode":
                            {
                                SelectNode = ob;
                                //DoMove
                                if (HaveSelectChess)
                                {
                                    BaseFunc.TeamMoveToNode(SelectChess, SelectNode);

                                }
                                else if (!HaveSelectChess)
                                {
                                    if (ob.tag == NodeType.Commander)
                                    {
                                        BaseFunc.ShowButton(ob, ButtonEnum.Development);

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
            }



        }

    }


    private void SetButtonState()
    {
        if(SelectNode == null)
        {
            BaseFunc.SetButtonStateByEnum(ButtonEnum.Development, false);

        }
        else
        {
            if (SelectNode.tag != NodeType.Commander)
            {
                BaseFunc.SetButtonStateByEnum(ButtonEnum.Development, false);
            }
        }


    }



}
