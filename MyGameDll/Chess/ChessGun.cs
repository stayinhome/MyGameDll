using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.Chess
{
    class ChessGun : AbstractChess
    {


        void Start()
        {
            ChessType = ChessEnum.ChessGun;
            Attack = 2;
            Defent = 2;
            Operater = 2;
            View = 2;


        }



    }
}
