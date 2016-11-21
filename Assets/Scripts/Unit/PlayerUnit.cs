using UnityEngine;
using System.Collections;

public class PlayerUnit : Unit {

	// Use this for initialization
	void Start () {
		Health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			LevelLoader.loadLevel ("Island 2");
		}
	}
}
