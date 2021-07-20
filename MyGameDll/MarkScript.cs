using MyGameDll.MyEventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        MEventManager.Instance.AddListener(MyEventType.SelectNodeChange, SelectNode_Change);
        MEventManager.Instance.AddListener(MyEventType.SelectChessChange, SelectChess_Change);
    }

    private void SelectChess_Change(object render, EvenData evenData)
    {
        if(evenData.gameObject != null)
        {
            if (gameObject.activeSelf == false)
            {
                gameObject.SetActive(true);
            }
            gameObject.transform.position = evenData.gameObject.transform.position;

        }
        else 
        {
            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
        }

    }

    private void SelectNode_Change(object render, EvenData evenData)
    {
        if (evenData.gameObject != null)
        {
            if (gameObject.activeSelf == false)
            {
                gameObject.SetActive(true);
            }
            gameObject.transform.position = evenData.gameObject.transform.position;

        }
        else
        {
            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
