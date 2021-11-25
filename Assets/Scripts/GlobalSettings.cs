using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class GlobalSettings : MonoBehaviour
    {
        public static GlobalSettings Settings { get; set; }

        public float MovingSpeed;
        public long Score;
        public bool IsMute;
        public int SeletedPlayer;
        public int NumberOfStartGrounds;
        public GameObject GroundPrefab;
        public List<GameObject> GroundPrefabs;
        public List<Material> GlobalMaterilas;

        public static Random Random;

        public bool IsA;
        public bool IsS;
        public bool IsD;
        public bool IsF;
        public bool IsSpace;

        public int CameraCount;

        //true >
        //false <
        bool direction = true;

        private void Awake()
        {
            Random = new Random();

            if (Settings == null)
            {
                Settings = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public int GetRandom(int max)
        {
            int next = Random.Next(0, max);

            return next;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (CameraCount == 4 )
                {
                    direction = false;
                }

                if (CameraCount == 1)
                {
                    direction = true;
                }


                if (direction)
                {
                    CameraCount++;
                }
                else
                {
                    CameraCount--;
                }
            }
        }
    }
}
