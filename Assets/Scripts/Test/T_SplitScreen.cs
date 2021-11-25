using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class T_SplitScreen:MonoBehaviour
    {
        private GameObject camera;
        private int numberOfSceneCamera;
        void Start()
        {
            GlobalSettings.Settings.CameraCount = 1;

            CreateCamera();
            numberOfSceneCamera = 1;
        }
        

        void Update()
        {
            numberOfSceneCamera = GameObject.FindGameObjectsWithTag("SplitCamera").Count();

            if (GlobalSettings.Settings.CameraCount > numberOfSceneCamera)
            {
                CreateCamera();
            }

            if (GlobalSettings.Settings.CameraCount < numberOfSceneCamera)
            {
                DestroyLastCamera();
            }
        }

        public void CreateCamera()
        {
            camera = new GameObject("Camera");
            camera.AddComponent<Camera>();

            camera.name = "SplitCamera" + GlobalSettings.Settings.CameraCount;
            camera.tag = "SplitCamera";

            if (GlobalSettings.Settings.CameraCount == 1)
            {
                camera.GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1f, 1.0f);
            }

            if (GlobalSettings.Settings.CameraCount == 2)
            {
                GameObject camera1 = GameObject.Find("SplitCamera1");
                camera1.GetComponent<Camera>().rect = new Rect(0.0f, 0, 0.5f, 1f);
                camera.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1f);
            }

            if (GlobalSettings.Settings.CameraCount == 3)
            {
                GameObject camera1 = GameObject.Find("SplitCamera1");
                GameObject camera2 = GameObject.Find("SplitCamera2");
                camera1.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                camera2.GetComponent<Camera>().rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
                camera.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }

            if (GlobalSettings.Settings.CameraCount == 4)
            {
                camera.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            }

            #region Test
            camera.GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
            switch (GlobalSettings.Settings.CameraCount)
            {
                case 1:
                    camera.GetComponent<Camera>().backgroundColor = Color.red;
                    break;
                case 2:
                    camera.GetComponent<Camera>().backgroundColor = Color.blue;
                    break;
                case 3:
                    camera.GetComponent<Camera>().backgroundColor = Color.yellow;
                    break;
                case 4:
                    camera.GetComponent<Camera>().backgroundColor = Color.black;
                    break;
            }
            #endregion
        }

        public void DestroyLastCamera()
        {
            List<GameObject> cameras = GameObject.FindGameObjectsWithTag("SplitCamera").ToList();

            Destroy(cameras.FirstOrDefault(c => c.name.EndsWith(numberOfSceneCamera.ToString())));
        }
    }
}
