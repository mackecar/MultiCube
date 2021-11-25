using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class T_Moving : MonoBehaviour
    {

        public readonly float Speed = 6;

        public bool CanJump = true;
        public bool CanMove = true;


        // Update is called once per frame
        void Update()
        {

            #region Player 1
            if (this.gameObject.tag == "Player1")
            {
                if (CanMove)
                {
                    float translation = Input.GetAxis("Left1Horizontal") * Speed;

                    translation *= Time.deltaTime;

                    transform.Translate(translation, 0, 0);
                }

                if (Input.GetAxis("Left1Vertical") > 0 && CanJump)
                {
                    //CanMove = false;
                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50 * Speed, 0));

                    CanJump = false;

                }
            }
            #endregion

            #region Player 2
            if (this.gameObject.tag == "Player3")
            {
                if (CanMove)
                {
                    float translation = Input.GetAxis("Right1Horizontal") * Speed;

                    translation *= Time.deltaTime;

                    transform.Translate(translation, 0, 0);
                }

                if (Input.GetAxis("Right1Vertical") > 0 && CanJump)
                {
                    //CanMove = false;

                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50 * Speed, 0));

                    CanJump = false;
                }
            }
            #endregion

            #region Player 3
            if (this.gameObject.tag == "Player2")
            {
                if (CanMove)
                {
                    float translation = Input.GetAxis("Left2Horizontal") * Speed;

                    translation *= Time.deltaTime;

                    transform.Translate(translation, 0, 0);
                }

                if (Input.GetAxis("Left2Vertical") < 0 && CanJump)
                {
                    //CanMove = false;

                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50 * Speed, 0));

                    CanJump = false;
                }
            }


            #endregion

            #region Player 4
            if (this.gameObject.tag == "Player4")
            {
                #region za razmotriti
                //float translation = Input.GetAxis("Right2Horizontal") * Speed;

                //translation *= Time.deltaTime;

                //transform.Translate(translation, 0, 0); 
                #endregion

                if (Input.GetButton("Right2HorizontalLeft") && CanMove)
                {
                    float translation = -1 * Speed;

                    translation *= Time.deltaTime;

                    transform.Translate(translation, 0, 0);
                }

                if (Input.GetButton("Right2HorizontalRight") && CanMove)
                {
                    float translation = 1 * Speed;

                    translation *= Time.deltaTime;

                    transform.Translate(translation, 0, 0);
                }

                if (Input.GetButton("Right2HorizontalUp") && CanJump)
                {
                    //CanMove = false;

                    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50 * Speed, 0));

                    CanJump = false;
                }
            }
            #endregion


        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name.Contains("Ground"))
            {
                CanJump = true;
                //CanMove = true;
            }
        }
    }
}
