using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameDll.Model.Dto
{
    class TeamData
    {
        public int TeamID = 0;

        /// <summary>
        /// 类型
        /// </summary>
        public TeamEnum TeamType = TeamEnum.None;


        private int _BaseNumber = 0;
        /// <summary>
        /// 基础数值
        /// </summary>
        public int BaseNumber
        {

            get
            {
                return _BaseNumber;
            }

            set
            {
                _BaseNumber = value;

            }
        }


        /// <summary>
        /// 基础行动点
        /// </summary>
        public int BaseOperater = 0;


        /// <summary>
        /// 基础视野
        /// </summary>
        public int BaseView = 0;



        /// <summary>
        /// 阵营
        /// </summary>
        public CampEnum Camp = CampEnum.None;

        /// <summary>
        /// 成员
        /// </summary>
        public List<AbstractRole> Member = new List<AbstractRole>();

    }
}
