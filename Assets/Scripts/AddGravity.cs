using UnityEngine;
using System.Collections;

public class AddGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.name ==  "Player") {
			if (Random.Range (0, 25) == 1) {
				gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				gameObject.GetComponent<Rigidbody> ().useGravity = true;
				Destroy (gameObject, 5f);

			}
		}

	}

	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player")) {
			if (Random.Range (0, 10) == 1) {
				gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				gameObject.GetComponent<Rigidbody> ().useGravity = true;
				Destroy (gameObject, 5f);

			}
		}
	}
}
