using UnityEngine;
using System.Collections;

public class CreateShield : MonoBehaviour {

	public GameObject shield;
	Transform player;

	private GameObject cloneShield;
	private bool canSpawn = true;
	private float timeUntilNextSpawn;

	private AudioSource audioSource;
	public AudioClip shieldSound;

	// Use this for initialization
	void Start () {
		player = this.transform;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		SpawnShield ();
	}

	void SpawnShield(){
		if (canSpawn && Input.GetKeyDown (KeyCode.B)) {
			cloneShield = Instantiate (shield);
			cloneShield.transform.position = new Vector3 (player.position.x, player.position.y - 2, player.position.z);
			audioSource.clip =  shieldSound;
			audioSource.Play ();
			canSpawn = false;
			timeUntilNextSpawn = 0.0f;
		}

		if (!canSpawn) {
			timeUntilNextSpawn += Time.deltaTime;
		}

		if (timeUntilNextSpawn >= 7) {
			canSpawn = true;
			Destroy (cloneShield);
		}
	}
}
