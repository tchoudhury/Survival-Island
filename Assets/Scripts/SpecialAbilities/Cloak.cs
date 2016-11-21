using UnityEngine;
using System.Collections;

public class Cloak : MonoBehaviour {

	public Material[] materials;
	int materialCount = 0;

	AudioSource audioSource;
	public AudioClip[] sounds;
	int soundsCount = 0;
	Renderer objectRenderer;

	// Use this for initialization
	void Start () {
		objectRenderer = GetComponent<Renderer> ();
		audioSource = GetComponentInParent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		ActivateCloak ();
	}

	void ActivateCloak(){
		if(Input.GetKeyDown(KeyCode.C)){
			objectRenderer.material = materials[GetNextMaterialIndex()];
			audioSource.clip = sounds[GetNextSoundIndex()];
			audioSource.Play ();

		}
	}

	int GetNextMaterialIndex(){
		materialCount++;
		if(materialCount == materials.Length){
			materialCount = 0;
		}

		return materialCount;
	}

	int GetNextSoundIndex(){
		soundsCount++;
		if (soundsCount == sounds.Length) {
			soundsCount = 0;
		}

		return soundsCount;
	}
}
