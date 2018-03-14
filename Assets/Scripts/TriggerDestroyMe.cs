using UnityEngine;
using System.Collections;

public class TriggerDestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, -15f, 0f);
	}

	void OnTriggerEnter(Collider c){

		if (c.CompareTag ("Player")) {
			GameObject.Find ("Player").GetComponent<Player> ().deathScreen ();
		}
		Destroy (c.gameObject);
	}
}
