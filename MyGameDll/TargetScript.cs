using MyGameDll;
using MyGameDll.Interface;
using MyGameDll.Model.Team;
using MyGameDll.MyEventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject Team = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) 
            && GlobalObject.CurDoFireSupportObject == Team 
            && GlobalObject.CurOperation == OperationType.FireSupport)
        {
            GameObject Node = BaseFunc.GetNodeByClick();
            if (Node!=null)
            {
                ISupport SupportObject = Team.GetComponent<ISupport>();
                int Rang = (int)Vector3.Distance(Team.transform.position, Node.transform.position);
                if(Rang >= SupportObject.MinSupportRang && Rang <= SupportObject.MaxSupportRang)
                {
                    SupportObject.SupportNode = Node;
                    this.gameObject.transform.position = Node.transform.position;
                }

            }
            GlobalObject.CurOperation = OperationType.GamePanleControl;

        }
    }


}
