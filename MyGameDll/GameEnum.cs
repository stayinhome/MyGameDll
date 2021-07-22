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



    public enum BuildEnum
    {
        /// <summary>
        /// 路障
        /// </summary>
        Roadblocks = 0,

        /// <summary>
        /// 陷阱
        /// </summary>
        Trap = 1,

        /// <summary>
        /// 自动火炮
        /// </summary>
        Turret = 2,

        /// <summary>
        /// 据点/仓库
        /// </summary>
        Warehouse = 3,

        /// <summary>
        /// 指挥中继塔
        /// </summary>
        RelayTower = 4,

        /// <summary>
        /// 红外线定位点
        /// </summary>
        InfraredPositioning = 5,
    }

    public enum NodeEnum
    {
        Normol = 0,

        Commander = 1,

        HeavyArtillery = 2,

        HighPoints = 3,

        UAVControlCenter = 4,

        Airport = 5,

        Radar = 6,

        ArtilleryPosition = 7,

        Metro = 8,
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

        /// <summary>
        /// 重火炮
        /// </summary>
        public static string HeavyArtillery = "HeavyArtillery";

        /// <summary>
        /// 制高点
        /// </summary>
        public static string HighPoints = "HighPoints";

        /// <summary>
        /// 无人机集群控制中心
        /// </summary>
        public static string UAVControlCenter = "UAVControlCenter";

        /// <summary>
        /// 机场
        /// </summary>
        public static string Airport = "Airport";

        /// <summary>
        /// 雷达
        /// </summary>
        public static string Radar = "Radar";

        /// <summary>
        /// 火炮阵地
        /// </summary>
        public static string ArtilleryPosition = "ArtilleryPosition";

        /// <summary>
        /// 地铁
        /// </summary>
        public static string Metro = "Metro";


    }

    public enum ButtonEnum
    {
        None = 0,

        Development = 1,

        Building = 2,

    }

    public class ButtonType
    {
        public static string None = "None";

        public static string Development = "Development";

        public static string Building = "Building";


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
