using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class SupportTeam : AbstractTeam
    {

        /// <summary>
        /// 支援火力
        /// </summary>
        public int FireSupport
        {
            get
            {
                return CalFireSupport();
            }

        }

        /// <summary>
        /// 最小可支援范围
        /// </summary>
        public int MinSupportRang = 0;


        protected int _MaxSupportRang = 0;
        /// <summary>
        /// 最大可支援范围
        /// </summary>
        public int MaxSupportRang
        {
            get
            {
                return CalMaxSupportRang();
            }

            set
            {
                _MaxSupportRang = value;
            }
        }
        

        /// <summary>
        /// 支援地点
        /// </summary>
        public GameObject SupportNode = null;

        /// <summary>
        /// 计算最大可支援范围
        /// </summary>
        /// <returns></returns>
        protected virtual int CalMaxSupportRang()
        {
            return _MaxSupportRang;
        }

        protected virtual int CalFireSupport()
        {
            return CalAttack();
        }
    }
}
