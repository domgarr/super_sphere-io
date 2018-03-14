using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {
	private float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = Time.time + 60f;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(new Vector3(-0.5f,0,0)*Time.deltaTime);

		if (Time.time > currentTime) {
			Destroy (gameObject);
		}
	}
}
