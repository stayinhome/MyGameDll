
using MyGameDll.Abstract;
using MyGameDll.Model.Abstract;
using UnityEngine;


namespace MyGameDll.Model.Building
{
    public class Roadblocks : AbstractBuilding
    {


        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.layer == (int)Layer.Chess)
            {
                AbstractTeam TeamProperty = other.gameObject.GetComponent<AbstractTeam>();
                if (TeamProperty.Camp != Camp)
                {
                    TeamProperty.Operater = 0;
                    CurNode.GetComponent<AbstractNode>().OtherObject = null;
                    Destroy(gameObject);

                }

            }
        }
    }
}