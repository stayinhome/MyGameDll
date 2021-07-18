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
                                    GameObject SelectChessCurNode = SelectChess.GetComponent<AbstractTeam>().CurNode;
                                    if (EnemyCurNode.GetComponent<AbstractNode>().IsNextNode(SelectChessCurNode))
                                    {
                                        if (SelectChess.GetComponent<AbstractTeam>().Operater > 0)
                                        {
                                            SelectChessCurNode.GetComponent<AbstractNode>().CurTeam.Remove(SelectChess);
                                            SelectChess.GetComponent<AbstractTeam>().Operater--;
                                            SelectChess.transform.position = new Vector3(EnemyCurNode.transform.position.x, EnemyCurNode.transform.position.y, SelectChess.transform.position.z);
                                            EnemyCurNode.GetComponent<AbstractNode>().CurTeam.Add(SelectChess);
                                            SelectChess.GetComponent<AbstractTeam>().CurNode = EnemyCurNode;
                                        }
                                    }

                                }

                                break;
                            }
                        case "Commander":
                        case "NullNode":
                            {
                                SelectNode = ob;
                                //DoMove
                                if (HaveSelectChess && ob.GetComponent<AbstractNode>().IsNextNode(SelectChess.GetComponent<AbstractTeam>().CurNode))
                                {
                                    if (SelectChess.GetComponent<AbstractTeam>().Operater > 0)
                                    {
                                        SelectChess.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().CurTeam.Remove(SelectChess);
                                        SelectChess.GetComponent<AbstractTeam>().Operater--;
                                        SelectChess.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y, SelectChess.transform.position.z);
                                        SelectNode.GetComponent<AbstractNode>().CurTeam.Add(SelectChess);
                                        SelectChess.GetComponent<AbstractTeam>().CurNode = ob;
                                    }
                                }
                                else if (!HaveSelectChess)
                                {
                                    if (ob.tag == "Commander")
                                    {
                                        BaseFunc.ShowButton(ob, ButtonEnum.Development);

                                    }

                                }
                                break;
                            }
                    }

                }
                else
                {
                    SelectNode = null;
                    SelectChess = null;
                }
            }



        }

    }






}
