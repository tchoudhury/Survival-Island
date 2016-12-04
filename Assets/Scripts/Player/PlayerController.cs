using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class PlayerController : MonoBehaviour
    {
		bool canJump = false;

        private CharacterController controller;
		private FirstPersonController fpsController;
        private PlayerGUI playerGUI;
		private PlayerUnit playerUnit;

		void Awake(){
				
		}

        // Use this for initialization
        void Start()
        {
            controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
			fpsController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
			playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUnit>();
            playerGUI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGUI>();

			SetUpGui ();
        }

        // Update is called once per frame
        void Update()
        {
			StaminaControls ();
        }

		void SetUpGui(){
			playerGUI.maxHealth = playerUnit.Health;
			playerGUI.maxStamina = playerUnit.Stamina;
		}

		void StaminaControls()
		{

			if (controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
			{
				if (!fpsController.IsWalking) {
					fpsController.RunSpeed = playerUnit.RunSpeed;
					playerGUI.LoseStamina(Time.deltaTime / playerUnit.RunStaminaFallRate);
				}
			}
			else
			{
				fpsController.WalkSpeed = playerUnit.WalkSpeed;

				if (controller.isGrounded) {
					playerGUI.GainStamina(Time.deltaTime / playerUnit.RunStaminaFallRate * 4);
				}
			}

			if (playerGUI.currentStamina <= playerUnit.JumpStaminaFallRate) {
				canJump = false;
				fpsController.Jump = canJump;
			}

			if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
			{
				playerGUI.GainStamina(playerUnit.JumpStaminaFallRate);
				Wait();
			}

			if (controller.isGrounded) {
				canJump = true;
			} else {
				canJump = false;
			}

			if (playerGUI.currentStamina <= 0) {
				fpsController.RunSpeed = playerUnit.WalkSpeed;
			}

			if (canJump == false)
			{
				fpsController.Jump = false;
			}

			if (playerGUI.currentStamina >= 1)
			{
				playerGUI.currentStamina = 1;
			}

			if (playerGUI.currentStamina <= 0)
			{
				playerGUI.currentStamina = 0;
				fpsController.RunSpeed = playerUnit.WalkSpeed;
			}
		}

		IEnumerator Wait()
		{
			yield return new WaitForSeconds(0.1f);
			canJump = false;
		}
    }
}
