using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Interface
{
    public interface ITeamBuff
    {
        /// <summary>
        /// 攻击力影响
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="AttackNumber"></param>
        /// <returns></returns>
        int BuffAttack(GameObject gameObject, int AttackNumber);

        /// <summary>
        /// 防御力影响
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="DefentNumber"></param>
        /// <returns></returns>
        int BuffDefent(GameObject gameObject, int DefentNumber);


        /// <summary>
        /// 行动力影响
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="OperaterNumber"></param>
        /// <returns></returns>
        int BuffOperater(GameObject gameObject, int OperaterNumber);

        /// <summary>
        /// 视野影响
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="OperaterNumber"></param>
        /// <returns></returns>
        int BuffView(GameObject gameObject, int ViewNumber);

    }
}