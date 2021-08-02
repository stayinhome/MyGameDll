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

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.layer == (int)Layer.Chess)
        //    {
        //        if(collision.gameObject.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
        //        {
        //            GlobalObject.MaterialCount += Material;
        //        }

        //        Destroy(gameObject);
                
        //    }
        //}
        public void AddMaterial(GameObject Go)
        {
            if (Go.layer == (int)Layer.Chess)
            {
                if (Go.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                {
                    GlobalObject.MaterialCount += Material;
                }

                Destroy(gameObject);

            }
        }

    }
}
