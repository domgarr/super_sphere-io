using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {
	private float nextCleanTime;
	private float nextCleanRate = 2f;
	// Use this for initialization
	void Start () {
		nextCleanTime = Time.time + nextCleanRate;
	}
	
	// Update is called once per frame

	void Update(){
		if (Time.time > nextCleanTime) {
			DeleteUnseen ();
		}
	}

	public void DeleteUnseen () {
			if (Camera.main.transform.position.x - 15 > gameObject.transform.position.x) {
				Destroy (gameObject);
			}
	}
}
