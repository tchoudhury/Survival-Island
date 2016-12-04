using UnityEngine;
using System.Collections;

public class PlayerUnit : Unit {

	[SerializeField] float stamina;
	[SerializeField] float runStaminaFallRate;
	[SerializeField] float jumpStaminaFallRate;

	// Use this for initialization
	void Awake () {
		Health = 100;
		stamina = 100;
		WalkSpeed = 6;
		RunSpeed = 10;
		runStaminaFallRate = 35;
		jumpStaminaFallRate = 0.2f;
		Damage = 25;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public float Stamina {
		get { 
			return stamina;
		}
	}

	public float RunStaminaFallRate {
		get {
			return runStaminaFallRate;
		}
	}
	public float JumpStaminaFallRate {
		get {
			return jumpStaminaFallRate;
		}
	}
}
