﻿using UnityEngine;
using System.Collections;

public class LightFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Light light = GetComponent<Light> ();
		light.range = Mathf.Lerp (light.range, 0, Time.deltaTime);
	}
}
