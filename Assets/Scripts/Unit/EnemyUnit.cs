using UnityEngine;
using System.Collections;

public class EnemyUnit : Unit {

	// Use this for initialization
	void Start () {
		Health = 5;
		Damage = 2;
		WalkSpeed = 4;
		RunSpeed = 7;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void ApplyDamage(int incomingDamage){
		Health -= incomingDamage;
		if(Health <= 0.0){
			Invoke("DelayedDetonate",0);
		} 
	}

	void DelayedDetonate(){
		Destroy(gameObject);
	}
}
