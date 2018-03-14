using UnityEngine;
using System.Collections;
	
public class NarrowVision : MonoBehaviour {
	private Light l;
	private float t;
	// Use this for initialization
	void Start () {
		t = 0.0f;
		l = GameObject.Find("Directional Light").GetComponent<Light>();


	}
	
	// Update is called once per frame
	void Update () {
				t+= 0.5f * Time.deltaTime;
				l.intensity = Mathf.Lerp(0f,1f,t);
	
		Destroy (gameObject, 2f);
	
	}
}
