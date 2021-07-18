using MyGameDll.MyEventManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.UI
{
    public class TXTOperater : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            MEventManager.Instance.AddListener(MyEventType.SelectChessChange, SelectChess_Change);
            MEventManager.Instance.AddListener(MyEventType.SelectChessOperaterValueChange, SelectChess_Change);

        }

        private void SelectChess_Change(object go, EvenData evenData)
        {
            if (evenData.gameObject != null)
            {
                go.text = "OperaterValue : " + evenData.gameObject.GetComponent<AbstractTeam>().Operater.ToString();
            }
            else if (evenData.Value != null)
            {
                txtOperaterValue.text = "OperaterValue : " + evenData.Value.ToString();
            }
            else
            {
                txtOperaterValue.text = "OperaterValue : 0";

            }
        }


    }
}
