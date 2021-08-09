using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    public class BuildingButton : MonoBehaviour
    {

        public GameObject BuildingPanel = null;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob == this.gameObject)
                {
                    GlobalObject.CurOperation = OperationType.Building;

                    BuildingPanel.SetActive(true);
                    BuildingPanel.GetComponent<BuildingCreat>().SelectTeam = GlobalObject.CurSelectChess;

                    BaseFunc.IniButtonState();

                }

            }

        }

    }
}
