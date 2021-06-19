using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    internal class BaseFunc
    {

        public static void ShowButton(GameObject go,ButtonEnum Type)
        {
            GameObject Ngo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Ngo.transform.position = new Vector3(go.transform.position.x + 10, go.transform.position.y + 10, go.transform.position.z);
            Ngo.AddComponent<AbstractButton>().Type = Type;
        }

    }
}