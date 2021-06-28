﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public class CameraControl : MonoBehaviour
    {

        public float Speed = 1.0f;


        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                transform.Translate(Vector3.left * Input.GetAxis("Mouse X") * Speed);
                transform.Translate(Vector3.up * Input.GetAxis("Mouse Y") * -Speed);
            }

        }


    }
}
