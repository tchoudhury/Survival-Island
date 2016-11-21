using UnityEngine;
using System.Collections;

public class ViewSwitch : MonoBehaviour {

	public Camera fpsCamera;
	public Camera thirdPersonCamera;
	bool canSwitch = false;

	void Start(){
		fpsCamera.enabled = true;
		thirdPersonCamera.enabled = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			canSwitch = !canSwitch;
		}

		if (canSwitch) {
			fpsCamera.enabled = false;
			thirdPersonCamera.enabled = true;
		} else {
			fpsCamera.enabled = true;
			thirdPersonCamera.enabled = false;
		}
	}
		
}
