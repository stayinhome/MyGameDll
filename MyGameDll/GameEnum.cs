using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyGameDll
{


    public enum Layer
    {
        Chess = 7,

        Node = 6,

    }

    public enum TeamEnum
    {
        None = 0,

        ChessGun = 1,

    }

    public enum NodeEnum
    {
        Normol = 0,

        Commander =1,
    }

    public enum ButtonEnum
    {
        None = 0,

        Development = 1,

    }

    public enum CampEnum
    {
        None = 0,

        Player = 1,

        Enemy =2,


    }

    public enum PanelType
    {
        GamePanel = 0,

        TeamPanel = 1,
    }

    public enum RoleTypeEnum
    {
        None = 0,
    }

    public enum RoundTypeEnum
    {
        Player = 0,

        Enemy = 1,
    }
}
