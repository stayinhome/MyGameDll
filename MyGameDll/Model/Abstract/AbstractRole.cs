﻿using InformationManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Abstract
{
    public abstract class AbstractRole : MonoBehaviour, ISpeakInterface
    {
        public int RoleID = 0;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 基础数值
        /// </summary>
        public int BaseValue { get; set; }

        /// <summary>
        /// 携带物资
        /// </summary>
        public int Material = 0;

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleTypeEnum RoleType = RoleTypeEnum.None;


        public virtual SpeakResult Speak(SpeakEnvironment environment)
        {
            return new SpeakResult();

        }

    }
}