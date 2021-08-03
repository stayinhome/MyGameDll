using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


namespace MyGameDll.Interface
{
    public interface ISupport
    {

        /// <summary>
        /// 火力支援标记
        /// </summary>
        GameObject Target { get; set; }

        /// <summary>
        /// 最小可支援范围
        /// </summary>
        int MinSupportRang { get; set; }

        /// 最大可支援范围
        /// </summary>
        int MaxSupportRang { get; set; }

        /// <summary>
        /// 已行动支援过
        /// </summary>
        bool IsWasSupport { get; set; }

        /// <summary>
        /// 支援地点
        /// </summary>
        GameObject SupportNode { get; set; }

        /// <summary>
        /// 支援火力
        /// </summary>
        int FireSupport { get; }

        /// <summary>
        /// 所属阵营
        /// </summary>
        CampEnum BelongCamp { get; set; }

}
}