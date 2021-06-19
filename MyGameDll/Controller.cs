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
            GameObject ob = GetObject();
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
                            }else if (!HaveSelectChess)
                            {
                                if(ob.tag == "Commander")
                                {

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



    private GameObject GetObject()
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



}
