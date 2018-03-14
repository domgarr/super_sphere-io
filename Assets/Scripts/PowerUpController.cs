using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,45,0) *Time.deltaTime);
	}


	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player") ) {
			c.gameObject.GetComponent<PlayerController> ().pickupPowerUp (gameObject.name);
			Destroy (gameObject);
		}
	}
}
