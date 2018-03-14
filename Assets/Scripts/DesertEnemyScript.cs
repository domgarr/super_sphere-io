using UnityEngine;
using System.Collections;

public class DesertEnemyScript : MonoBehaviour {
	public GameObject gust;
	public GameObject narrowVision;
	private float gustCooldown;
	// Use this for initialization
	void Start () {
		gustCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Player") && Time.time > gustCooldown) {
			Instantiate (gust, transform.position, transform.localRotation);
			Instantiate (narrowVision, transform.position, transform.localRotation);
			gustCooldown = Time.time + 3f;
		}
	}
}
