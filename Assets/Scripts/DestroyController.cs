using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyController:MonoBehaviour
    {
        private GameObject GameEngine;

        void Start()
        {
            GameEngine = this.gameObject.transform.parent.gameObject;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ground")
            {
                Destroy(other.gameObject);

                GameEngine.GetComponent<LoadGroundController>().CrateNewGround();
            }

        }
    }
}
