using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	[SerializeField] int health;
	[SerializeField] int walkSpeed;
	[SerializeField] int runSpeed;
	[SerializeField] int damage;

	public int Health {
		get {
			return health;
		}
		set {
			health = value;
		}
	}

	public int WalkSpeed {
		get {
			return walkSpeed;
		}
		set {
			walkSpeed = value;
		}
	}

	public int RunSpeed {
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
