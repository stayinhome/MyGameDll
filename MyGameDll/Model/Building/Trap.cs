using MyGameDll.Abstract;
using MyGameDll.Model.Abstract;
using UnityEngine;


namespace MyGameDll.Model.Building
{
    public class Trap : AbstractBuilding
    {

        public int Damage = 4;


        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.layer == (int)Layer.Chess)
            {
                AbstractTeam TeamProperty = other.gameObject.GetComponent<AbstractTeam>();
                if (TeamProperty.Camp != Camp)
                {
                    int TempNumber = TeamProperty.Defent - Damage;
                    if(TempNumber <=0)
                    {
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        TeamProperty.BaseNumber = TeamProperty.BaseNumber * (TempNumber / TeamProperty.Defent);
                    }
                    CurNode.GetComponent<AbstractNode>().OtherObject = null;
                    Destroy(this.gameObject);

                }

            }
        }
    }
}