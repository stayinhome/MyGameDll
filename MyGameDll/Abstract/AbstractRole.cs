using InformationManagement;
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
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; } 


        public virtual SpeakResult Speak(SpeakEnvironment environment)
        {
            return new SpeakResult();

        }

    }
}