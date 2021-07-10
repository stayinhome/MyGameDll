using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameDll;
using System;
using MyGameDll.Abstract;
using MyGameDll.MyEventManager;

public class Controller : MonoBehaviour
{
    public GameObject SelectChess;

    private GameObject _SelectNode;
    public GameObject SelectNode
    {
        get { return _SelectNode; }
        set
        {
            _SelectNode = value;
            MyEventManager.Instance.DispatchEvent(MyEventType.SelectNodeChange,value);
        }
    }


    public bool HaveSelectChess
    {
        get
        {
            return SelectChess != null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //IniState();

            GameObject ob = BaseFunc.GetObjectByClick();
            if(ob != null)
            {
                Layer type = (Layer)ob.layer;
                switch (type)
                {
                    case Layer.Chess:
                        {
                            SelectChess = ob;
                            break;
                        }
                    case Layer.Node:
                        {
                            SelectNode = ob;
                            //DoMove
                            if (HaveSelectChess && ob.GetComponent<AbstractNode>().IsNextNode(SelectChess.GetComponent<AbstractTeam>().CurNode))
                            {
                                if (SelectChess.GetComponent<AbstractTeam>().Operater-- > 0)
                                {
                                    SelectChess.GetComponent<AbstractTeam>().CurNode.GetComponent<AbstractNode>().CurTeam.Remove(SelectChess);
                                    SelectChess.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y, SelectChess.transform.position.z);
                                    SelectNode.GetComponent<AbstractNode>().CurTeam.Add(SelectChess);
                                    SelectChess.GetComponent<AbstractTeam>().CurNode = ob;
                                }
                            }
                            else if (!HaveSelectChess)
                            {
                                if(ob.tag == "Commander")
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

    public void IniState()
    {
        BaseFunc.SetButtonStateByName("Development", false);

    }





}
