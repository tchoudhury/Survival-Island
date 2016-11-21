using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class UnderWater : MonoBehaviour {

	public float waterLevel;
	public ParticleSystem bubbleParticles;
	private bool isUnderWater;
	private Color normalColor;
	private Color underWaterColor;
	private FirstPersonController controller;

	private bool canSwim = false;
	private bool underGround = false;
	public float groundLevel;

	// Use this for initialization
	void Start () {
		normalColor = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		underWaterColor = new Color (0.22f, 0.65f, 0.77f, 0.5f);
		controller = GetComponent<FirstPersonController> ();
		bubbleParticles.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetNormal(){
		RenderSettings.fogColor = normalColor;
		RenderSettings.fogDensity = 0.002f;

	}
}
