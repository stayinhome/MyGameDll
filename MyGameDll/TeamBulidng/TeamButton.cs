using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class TeamButton : MonoBehaviour
    {

        public GameObject TempTeam = new GameObject();

        void Start()
        {
            try
            {
                AbstractTeam TeamProperty = TempTeam.GetComponent<AbstractTeam>();
                if (TeamProperty != null)
                {
                    Destroy(TeamProperty);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
            TempTeam.AddComponent<AbstractTeam>();

        }

    }
}
