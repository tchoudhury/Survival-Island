using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayerController : MonoBehaviour
    {

        private bool hasAxe = false;

        private bool canSwing = true;
        private bool isSwinging = false;
        public float swingTimer = 0.7f;

        private CharacterController controller;
        private PlayerGUI playerGUI;

        // Use this for initialization
        void Start()
        {
            hasAxe = true;
            controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
            playerGUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            AxeSwing();
        }

        void AxeSwing()
        {
            if (controller.velocity.magnitude <= 0 && isSwinging == false)
            {
                GetComponent<Animation>().Play("Idle");
                GetComponent<Animation>()["Idle"].wrapMode = WrapMode.Loop;
                GetComponent<Animation>()["Idle"].speed = 0.2f;
            }

            if (controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animation>().Play("Sprint");
                GetComponent<Animation>()["Sprint"].wrapMode = WrapMode.Loop;
            }

            if (hasAxe == true && canSwing == true)
            {
				if (Input.GetButtonDown("Fire2"))
                {
                    playerGUI.StaminaBarDisplay -= 0.1f;

                    GetComponent<Animation>().Play("Swing");
                    GetComponent<Animation>()["Swing"].speed = 2f;
                    isSwinging = true;
                    canSwing = false;
                }
            }

            if (canSwing == false)
            {
                swingTimer -= Time.deltaTime;
            }

            if (swingTimer <= 0)
            {
                swingTimer = 1;
                canSwing = true;
                isSwinging = false;
            }
        }

		public bool IsSwinging{
			get{ return isSwinging;}
			set{ isSwinging = value;}
		}

		public bool CanSwing{
			get{ return canSwing;}
			set{ canSwing = value;}
		}
    }
}
