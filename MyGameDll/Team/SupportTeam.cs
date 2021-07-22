using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Team
{
    public class SupportTeam : AbstractTeam
    {
        /// <summary>
        /// 支援火力
        /// </summary>
        public int FireSupport = 0;

        /// <summary>
        /// 最小可支援范围
        /// </summary>
        public int MinSupportRang = 0;

        /// <summary>
        /// 最大可支援范围
        /// </summary>
        public int MaxSupportRang = 0;

        /// <summary>
        /// 支援地点
        /// </summary>
        public GameObject SupportNode = null;
    }
}
