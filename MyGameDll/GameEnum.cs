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

        /// <summary>
        /// 步兵
        /// </summary>
        Rifle = 1,

        /// <summary>
        /// 装甲
        /// </summary>
        Armor = 2,

        /// <summary>
        /// 火炮
        /// </summary>
        Artillery = 3,

        /// <summary>
        /// 机动
        /// </summary>
        Maneuver = 4,

        /// <summary>
        /// 狙击/侦查
        /// </summary>
        Sniper = 5,

        /// <summary>
        /// 空军
        /// </summary>
        Air = 6,

    }

    public enum NodeEnum
    {
        Normol = 0,

        Commander =1,
    }

    public enum BuildEnum
    {
        Roadblocks = 0,

        Trap = 1,

        Turret = 2,


    }

    public class NodeType
    {
        /// <summary>
        /// 空节点
        /// </summary>
        public static string Normol = "Null";

        /// <summary>
        /// 指挥所
        /// </summary>
        public static string Commander = "Commander";



    }

    public enum ButtonEnum
    {
        None = 0,

        Development = 1,

        Building = 2,

        Warehouse = 3,

    }

    public class ButtonType
    {
        public static string None = "None";

        public static string Development = "Development";

        public static string Building = "Building";

        public static string Warehouse = "Warehouse";


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

        /// <summary>
        /// 步兵
        /// </summary>
        Rifle = 1,

        /// <summary>
        /// 装甲
        /// </summary>
        Armor = 2,

        /// <summary>
        /// 火炮
        /// </summary>
        Artillery = 3,

        /// <summary>
        /// 机动
        /// </summary>
        Maneuver = 4,

        /// <summary>
        /// 狙击/侦查
        /// </summary>
        Sniper = 5,

        /// <summary>
        /// 空军
        /// </summary>
        Air = 6,
    }

    public enum RoundTypeEnum
    {
        Player = 0,

        Enemy = 1,
    }
}
