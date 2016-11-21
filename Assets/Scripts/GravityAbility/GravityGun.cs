using UnityEngine;
using System.Collections;

public class GravityGun : MonoBehaviour {
	
	public float catchRange = 30.0f;
	public float holdDistance = 4.0f;
	public int minForce = 1000;
	public int maxForce = 10000;
	public int forceChargePerSec = 3000;
	public LayerMask layerMask = -1;

	enum GravityGunState{Free, Catch, Occupied, Charge, Release};
	private GravityGunState gravityGunState = 0;
	private Rigidbody rigid = null;
	private float currForce;

	void Start() {
		currForce = minForce;
	}

	void FixedUpdate () {
		if(gravityGunState == GravityGunState.Free) {
			if(Input.GetKeyDown(KeyCode.N)) {
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(transform.position, transform.forward, out hit, catchRange, layerMask)) {
					if(hit.rigidbody) {
						rigid = hit.rigidbody;
						gravityGunState = GravityGunState.Catch;
					}
				}
			}
		} else if(gravityGunState == GravityGunState.Catch) {
			rigid.MovePosition(transform.position + transform.forward * holdDistance);

			if (Input.GetKeyDown(KeyCode.N)) {
				gravityGunState = GravityGunState.Occupied;
			}
		} else if(gravityGunState == GravityGunState.Occupied) {
			rigid.MovePosition(transform.position + transform.forward * holdDistance);

			if (Input.GetKeyDown(KeyCode.N)) {
				gravityGunState = GravityGunState.Charge;
			}
		} else if(gravityGunState == GravityGunState.Charge) {
			rigid.MovePosition(transform.position + transform.forward * holdDistance);

			if(currForce < maxForce) {
				currForce += forceChargePerSec * Time.deltaTime;
			} else {
				currForce = maxForce;
			}
				
			rigid.AddForce (Vector3.forward * currForce);
				
		}

	}

}
