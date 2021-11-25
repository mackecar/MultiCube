using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class T_MovingGround:MonoBehaviour
    {
        private float _movingSpeed;

        void Start()
        {
            _movingSpeed = GlobalSettings.Settings.MovingSpeed;
        }

        void Update()
        {
            transform.Translate(Vector3.back * Time.deltaTime * _movingSpeed);
        }
    }
}
