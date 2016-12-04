using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	[SerializeField] float health;
	[SerializeField] float walkSpeed;
	[SerializeField] float runSpeed;
	[SerializeField] int damage;

	public float Health {
		get {
			return health;
		}
		set {
			health = value;
		}
	}

	public float WalkSpeed {
		get {
			return walkSpeed;
		}
		set {
			walkSpeed = value;
		}
	}

	public float RunSpeed {
		get {
			return runSpeed;
		}
		set {
			runSpeed = value;
		}
	}

	public int Damage {
		get {
			return damage;
		}
		set {
			damage = value;
		}
	}
}
