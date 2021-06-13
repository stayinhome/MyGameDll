using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameDll;
using System;

public class ChessController : MonoBehaviour
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
                            if (HaveSelectChess)
                            {
                                if (SelectChess.GetComponent<AbstractChess>().Operater-- > 0)
                                {
                                    SelectChess.transform.position = ob.transform.position;
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
