using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyGameDll
{


    public enum Layer
    {

        Node = 6,

        Chess = 7,

        Other = 8,

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

        None = 0,


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

        /// <summary>
        /// 路障
        /// </summary>
        Roadblock = 6,

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

    public enum ButtonEnum
    {
        None = 0,

        Deploy = 1,

        Building = 2,

    }

    public class ButtonType
    {
        public const string None = "None";

        public const string Deploy = "Deploy";

        public const string Building = "Building";

        public const string DeployArtillery = "DeployArtillery";

        public const string FireSupport = "FireSupport";


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

    public class ResourcesPath
    {
        public static readonly string AirSpritePath = "icon/Air";

        public static readonly string RifleSpritePath = "icon/Rifle";

        public static readonly string ArmorSpritePath = "icon/Armor";

        public static readonly string ArtillerySpritePath = "icon/Artillery";

        public static readonly string ManeuverSpritePath = "icon/Maneuver";

        public static readonly string SniperSpritePath = "icon/Sniper";

        public static readonly string EnemySpritePath = "icon/Rifle";

        public static readonly string NoneSpritePath = "icon/None";

    }

    public enum OperationType
    {
        Null = 0,

        TeamReBuilding = 1,

        TeamDeploy = 2,

        FireSupport = 3,

        GamePanleControl = 4,

        Building = 5,

    }

    public enum CardType
    {

    }
}
