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
                    SupportTeam team = GlobalObject.CurSelectChess?.GetComponent<SupportTeam>();
                    if(team != null&&(team.TeamType != TeamEnum.Maneuver || team.TeamType != TeamEnum.Armor))
                    {
                        GlobalObject.CurOperation = OperationType.FireSupport;
                        team.Target.SetActive(true);
                        BaseFunc.IniButtonState();
                    }


                }

            }

        }
    }
}
