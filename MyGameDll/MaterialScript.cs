using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class MaterialScript : MonoBehaviour
    {
        public GameObject CurNode = null;

        public int Material = 0;


        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.layer == (int)Layer.Chess)
            {
                if (other.gameObject.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                {
                    GlobalObject.MaterialCount += Material;
                }

                Destroy(gameObject);

            }
        }


    }
}
