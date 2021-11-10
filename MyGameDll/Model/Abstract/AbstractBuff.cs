using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Model.Abstract
{
    public abstract class AbstractBuff 
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


        /// <summary>
        /// 具体效果
        /// </summary>
        /// <param name="Target"></param>
        public abstract void Buff(GameObject Target);





    }
}