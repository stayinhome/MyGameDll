using MyGameDll.Abstract;
using MyGameDll.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Model.Team
{
    public class SupportTeam : AbstractTeam , ISupport
    {
        /// <summary>
        /// 火力支援标记
        /// </summary>
        public GameObject Target { get; set; }

        /// <summary>
        /// 已行动支援过
        /// </summary>
        public bool IsWasSupport { get; set; } = false;

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
        public int MinSupportRang { get; set; }


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

        private GameObject _SupportNode = null;
        /// <summary>
        /// 支援地点
        /// </summary>
        public GameObject SupportNode
        {

            get
            {
                return _SupportNode;
            }

            set
            {
                _SupportNode?.GetComponent<AbstractNode>().FireSupport.Remove(this.gameObject);

                _SupportNode = value;

                _SupportNode?.GetComponent<AbstractNode>().FireSupport.Add(this.gameObject);


            }

        }

        /// <summary>
        /// 所属阵营
        /// </summary>
        public CampEnum BelongCamp { get { return Camp; } set { Camp = value; } }

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

        void Start()
        {
            Target = gameObject.transform.Find("Target").gameObject;
        }

        public override void DoMoveTo(GameObject Node)
        {
            base.DoMoveTo(Node);
            if (Target != null && Target.activeSelf)
            {
                Target.SetActive(false);
            }
        }

        public override void RefreshMe()
        {
            base.RefreshMe();
            IsWasSupport = false;
        }
    }
}
