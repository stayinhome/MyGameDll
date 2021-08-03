using MyGameDll.Interface;
using MyGameDll.Model.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    public class FireSupportButton : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob == this.gameObject)
                {
                    ISupport Support = GlobalObject.CurSelectChess?.GetComponent<ISupport>();
                    if(Support != null)
                    {
                        GlobalObject.CurOperation = OperationType.FireSupport;
                        Support.Target.SetActive(true);
                        BaseFunc.IniButtonState();
                    }


                }

            }

        }
    }
}
