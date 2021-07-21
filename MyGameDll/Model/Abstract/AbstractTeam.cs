using InformationManagement;
using MyGameDll.Abstract;
using MyGameDll.Model.Dto;
using MyGameDll.MyEventManager;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameDll
{
    public class AbstractTeam : MonoBehaviour
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
                if(gameObject != null)
                {
                    gameObject.BroadcastMessage("RefreshAttack", Attack);
                    gameObject.BroadcastMessage("RefreshDefent", Defent);
                }

            }
        }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int Attack
        {
            get
            {
                return _BaseNumber;
            }

        }
        
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defent
        {
            get
            {
                return _BaseNumber;
            }

        }


        /// <summary>
        /// 基础行动点
        /// </summary>
        public int BaseOperater = 0;

        public int _Operater = 0;
        /// <summary>
        /// 行动点
        /// </summary>
        public int Operater
        {
            get
            {
                return _Operater;
            }

            set
            {
                if(BaseOperater == 0)
                {
                    BaseOperater = value;
                }
                _Operater = value;

                EvenData evenData = new EvenData();
                evenData.Value = value;
                MEventManager.Instance.DispatchEvent(MyEventType.SelectChessOperaterValueChange,gameObject, evenData);
            }
        }

        /// <summary>
        /// 基础视野
        /// </summary>
        public int BaseView = 0;
        /// <summary>
        /// 视野
        /// </summary>
        public int View
        {
            get
            {
                return BaseView;
            }

        }

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
            Operater = BaseOperater;
        }

        public virtual void DoInit(TeamData teamData)
        {
            Camp = teamData.Camp;
        }

    }
}
