using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DebugController : MonoBehaviour
    {
        void Start()
        {
            if (GlobalSettings.Settings != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
