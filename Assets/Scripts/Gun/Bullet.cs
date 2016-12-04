using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody rbody;
	Collider collider;

	public float travelSpeed;
	public float lifetime;
	public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag != "enemy"){
			//explode ();
		}

		col.gameObject.GetComponent<
	}
}
