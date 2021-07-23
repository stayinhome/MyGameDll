using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyGameDll
{
    public class PropertyValue
    {
        /// <summary>
        /// 制高点提供视野
        /// </summary>
        public static int HighPointsAddView = 4;

        /// <summary>
        /// 制高点提供攻击范围
        /// </summary>
        public static int HighPointsAddRang = 4;

        /// <summary>
        /// 炮击阵地提供攻击范围
        /// </summary>
        public static int ArtilleryPositionAddRang = 4;

        /// <summary>
        /// 机动型攻击数值补正
        /// </summary>
        public static decimal ManeuverAttackCorrection = 1.5m;

        /// <summary>
        /// 机动型防御数值补正
        /// </summary>
        public static decimal ManeuverDefentCorrection = 0.5m;

        /// <summary>
        /// 狙击型支援火力数值补正
        /// </summary>
        public static decimal SniperSupportCorrection = 1.2m;

        /// <summary>
        /// 狙击型防御数值补正
        /// </summary>
        public static decimal SniperDefentCorrection = 0.2m;
        
        /// <summary>
        /// 火炮型支援火力数值补正
        /// </summary>
        public static decimal ArtillerySupportCorrection = 2.0m;

        /// <summary>
        /// 火炮型攻击数值补正
        /// </summary>
        public static decimal ArtilleryAttackCorrection = 0.1m;

        /// <summary>
        /// 火炮型防御数值补正
        /// </summary>
        public static decimal ArtilleryDefentCorrection = 0.5m;

        /// <summary>
        /// 空军支援火力数值补正
        /// </summary>
        public static decimal AirSupportCorrection = 2.0m;

        /// <summary>
        /// 空军攻击数值补正
        /// </summary>
        public static decimal AirAttackCorrection = 0.1m;

        /// <summary>
        /// 空军防御数值补正
        /// </summary>
        public static decimal AirDefentCorrection = 0.1m;

        /// <summary>
        /// 装甲型防御数值补正
        /// </summary>
        public static decimal ArmorDefentCorrection = 2.0m;

    }
}