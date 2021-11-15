using MyGameDll.Model.Abstract;
using UnityEngine;

namespace CardManagement.TeamBuffType
{
    public class DoubleDefentCard : TeamBuffCard
    {
        public DoubleDefentCard()
        {
            Count = 3;
        }

        public override int BuffDefent(GameObject gameObject, int DefentNumber)
        {
            return DefentNumber * 2;
        }
    }
}