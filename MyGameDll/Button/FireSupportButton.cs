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
                    ITarget Target = GlobalObject.CurSelectChess?.GetComponent<ITarget>();
                    if(Target != null)
                    {
                        GlobalObject.CurOperation = OperationType.FireSupport;
                        Target.Target.SetActive(true);
                        BaseFunc.IniButtonState();
                    }


                }

            }

        }
    }
}
