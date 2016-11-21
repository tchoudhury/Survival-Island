using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;
	[SerializeField] int hazardCount = 3;
	[SerializeField] float spawnWait = 0.5f;
	[SerializeField] float startWait = 1f;
	[SerializeField] float waveWait = 4f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);

		bool continueSpawning = true;
		while (continueSpawning) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			for (int i = 0; i < hazardCount; i++) {
				Instantiate (enemy, spawnPoints [spawnPointIndex].transform.position, Quaternion.identity);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);

		}
	}
}
