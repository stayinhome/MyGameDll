using MyGameDll.Abstract;
using UnityEngine;

namespace MyGameDll
{
    public abstract class AbstractChess : MonoBehaviour
    {
        /// <summary>
        /// 类型
        /// </summary>
        public ChessEnum ChessType { get; set; } = ChessEnum.None;

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

        public virtual void RefreshMe()
        {

        }

    }
}
