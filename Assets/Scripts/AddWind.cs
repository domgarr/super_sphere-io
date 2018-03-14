using UnityEngine;
using System.Collections;

public class AddWind : MonoBehaviour {
	public Transform playerPosition;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (playerPosition.position.x + 10f, 5f, 0f); 
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider c){
		if(c.CompareTag("Player")){
			c.gameObject.GetComponent<Rigidbody>().AddForce(-100f,-1f,0);
			Destroy (gameObject, 2f);
		}
		
	}

	
}
