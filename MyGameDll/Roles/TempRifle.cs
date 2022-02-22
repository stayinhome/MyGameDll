using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.Roles
{
    public class TempRifle : AbstractRole
    {

        void Start()
        {
            Name = "TempRifle";
            RoleType = RoleTypeEnum.Rifle;
        }

    }
}
