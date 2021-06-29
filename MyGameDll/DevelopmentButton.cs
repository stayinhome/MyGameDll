using MyGameDll;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopmentButton : MonoBehaviour
{
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ob = BaseFunc.GetObjectByClick();
            if(ob == this.gameObject)
            {
                BaseFunc.SetCanvasButtonStateByName("Canvas", "TeamPanel", true);

                this.gameObject.SetActive(false);
            }

        }

    }
}
