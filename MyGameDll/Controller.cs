using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameDll;
using System;
using MyGameDll.Abstract;

public class Controller : MonoBehaviour
{
    public GameObject SelectChess;

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
                            //DoMove
                            if (HaveSelectChess && ob.GetComponent<AbstractNode>().IsNextNode(SelectChess.GetComponent<AbstractChess>().CurNode))
                            {
                                if (SelectChess.GetComponent<AbstractChess>().Operater-- > 0)
                                {
                                    SelectChess.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y, SelectChess.transform.position.z);
                                    SelectChess.GetComponent<AbstractChess>().CurNode = ob;
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
                SelectChess = null;
            }


        }


    }

    public void IniState()
    {
        BaseFunc.SetButtonStateByName("Development", false);

    }





}
