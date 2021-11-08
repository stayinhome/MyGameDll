using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class MoveScript : MonoBehaviour
    {

        public bool Moveing = false;

        public int Speed = 20;

        public Vector3 TargetPosition = new Vector3();

  

        void FixedUpdate()
        {
            if (Moveing)
            {
                Vector3 offset = TargetPosition - transform.position;

                transform.position += offset.normalized * Speed * Time.deltaTime;

                if (Vector3.Distance(TargetPosition, transform.position) < 1f)
                {

                    transform.position = TargetPosition;

                    Moveing = false;

                }

            }
        }

        public void MoveToTarget(Vector3 end)
        {
            TargetPosition = end;

            Moveing = true;
        }


    }
}
