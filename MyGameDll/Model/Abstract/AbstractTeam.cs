using InformationManagement;
using MyGameDll.Abstract;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameDll
{
    public abstract class AbstractTeam : MonoBehaviour
    {
        /// <summary>
        /// 类型
        /// </summary>
        public TeamEnum TeamType { get; set; } = TeamEnum.None;

        /// <summary>
        /// 攻击力
        /// </summary>
        public int Attack = 0;

        /// <summary>
        /// 防御力
        /// </summary>
        public int Defent = 0;


        /// <summary>
        /// 行动点
        /// </summary>
        public int Operater = 0;

        /// <summary>
        /// 视野
        /// </summary>
        public int View = 0;

        /// <summary>
        /// 当前所在节点
        /// </summary>
        public GameObject CurNode = null;

        /// <summary>
        /// 阵营
        /// </summary>
        public CampEnum Camp = CampEnum.None;

        /// <summary>
        /// 成员
        /// </summary>
        public List<AbstractRole> Member = new List<AbstractRole>();


        public virtual void RefreshMe()
        {

        }


    }
}
