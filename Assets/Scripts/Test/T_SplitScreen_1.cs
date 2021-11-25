using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class T_SplitScreen_1:MonoBehaviour
    {
        public GameObject Camera1;
        public GameObject Camera2;
        public GameObject Camera3;
        public GameObject Camera4;
        public GameObject Camera5;

        private int numberOfActiveCamera;

        void Start()
        {
            GlobalSettings.Settings.CameraCount = 1;
            Camera5.gameObject.SetActive(false);

            Camera5.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);

            numberOfActiveCamera = 1;
        }

        void Update()
        {
            List<GameObject> cameraGameObjects = GameObject.FindGameObjectsWithTag("SplitCamera").ToList();
            numberOfActiveCamera = cameraGameObjects.Count(c => c.gameObject.activeSelf);

            if (GlobalSettings.Settings.CameraCount > numberOfActiveCamera)
            {
                SetActiveCamera();
            }

            if (GlobalSettings.Settings.CameraCount < numberOfActiveCamera)
            {
                SetActiveCamera();
            }
        }

        public void SetActiveCamera()
        {
            if (GlobalSettings.Settings.CameraCount == 1)
            {
                Debug.Log(1);
                Camera1.GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1f, 1.0f);
                Camera2.gameObject.SetActive(false);
                Camera3.gameObject.SetActive(false);
                Camera4.gameObject.SetActive(false);
                Camera5.gameObject.SetActive(false);
            }

            if (GlobalSettings.Settings.CameraCount == 2)
            {
                Debug.Log(2);
                Camera1.GetComponent<Camera>().rect = new Rect(0.0f, 0, 0.5f, 1f);
                Camera2.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1f);
                Camera2.gameObject.SetActive(true);
                Camera3.gameObject.SetActive(false);
                Camera4.gameObject.SetActive(false);
                Camera5.gameObject.SetActive(false);
            }

            if (GlobalSettings.Settings.CameraCount == 3)
            {
                Debug.Log(3);
                Camera1.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                Camera2.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                Camera3.GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 0.5f);
                Camera2.gameObject.SetActive(true);
                Camera3.gameObject.SetActive(true);
                Camera4.gameObject.SetActive(false);
                Camera5.gameObject.SetActive(true);
            }

            if (GlobalSettings.Settings.CameraCount == 4)
            {
                Debug.Log(4);
                Camera4.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
                Camera2.gameObject.SetActive(true);
                Camera3.gameObject.SetActive(true);
                Camera4.gameObject.SetActive(true);
                Camera5.gameObject.SetActive(false);
            }
        }

    }
}
