using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.Chess
{
    class ChessGun : AbstractTeam
    {


        void Start()
        {
            TeamType = TeamEnum.ChessGun;
            BaseNumber = 2;
            BaseOperater = 2;
            BaseView = 2;

        }

        public override void RefreshMe()
        {
            base.RefreshMe();
            Operater = 2;
        }


    }
}
