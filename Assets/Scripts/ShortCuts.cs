using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShortCuts:MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                GlobalSettings.Settings.IsA = !GlobalSettings.Settings.IsA;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                GlobalSettings.Settings.IsS = !GlobalSettings.Settings.IsS;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                GlobalSettings.Settings.IsD = !GlobalSettings.Settings.IsD;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                GlobalSettings.Settings.IsF = !GlobalSettings.Settings.IsF;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GlobalSettings.Settings.IsSpace = !GlobalSettings.Settings.IsSpace;
            }
        }
    }
}
