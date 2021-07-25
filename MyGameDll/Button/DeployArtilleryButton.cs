using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Button
{
    public class DeployArtilleryButton  : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ob = BaseFunc.GetObjectByClick();
                if (ob == this.gameObject)
                {


                    this.gameObject.SetActive(false);
                }

            }

        }

    }
}
