using MyGameDll.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Model.Abstract
{
    public class AbstractCard
    {
        /// <summary>
        /// 生效次数
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// 使用目标
        /// </summary>
        public GameObject Target = null;

        /// <summary>
        /// 是否需要目标
        /// </summary>
        public bool NeedTarget = false;


    }

    public class TeamBuffCard : AbstractCard ,ITeamBuff
    {
        public TeamBuffCard()
        {
            NeedTarget = true;
        }


        public virtual int BuffAttack(GameObject gameObject, int AttackNumber)
        {
            return AttackNumber;
        }


        public virtual int BuffDefent(GameObject gameObject, int DefentNumber)
        {
            return DefentNumber;
        }


        public virtual int BuffOperater(GameObject gameObject, int OperaterNumber)
        {
            return OperaterNumber;
        }


        public int BuffView(GameObject gameObject, int ViewNumber)
        {
            return ViewNumber;
        }
    }

    public class NoTargetCard : AbstractCard
    {

    }



}