using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	[SerializeField] int bulletDmg = 1;

	private Rigidbody bulletRigidbody;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if(Input.GetButtonDown("Fire1")){
			FireOneShot();
		}
	}

	void FireOneShot(){
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, direction, out hit, 300)) {
			Debug.DrawLine (transform.position, hit.point, Color.cyan);
			// - send damage to object we hit - \\
			hit.collider.SendMessageUpwards("ApplyDamage", bulletDmg, SendMessageOptions.DontRequireReceiver);
		}
	}
}
