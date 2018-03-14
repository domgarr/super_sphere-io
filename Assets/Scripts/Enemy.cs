using UnityEngine;
using System.Collections;

public  class Enemy : MonoBehaviour {

	private Rigidbody r;
	private int health;

	private bool chasePlayer;
	private bool changeDirection;
	private Vector3 v;

	private bool onMovingPlatform;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody>();
	
		chasePlayer = false;
		changeDirection = false;
		onMovingPlatform = false;
	}
	
	// Update is called once per frame
	void Update(){
		if (!changeDirection)
			v = new Vector3 (-1, 1, 0);
		else
			v = new Vector3 (1, 1, 0);
	
	

	}
	void FixedUpdate () {

		if (chasePlayer && !onMovingPlatform) {
			r.AddForce (v * 80, ForceMode.Force);
		}  
		if (Mathf.Abs (r.velocity.x) < 0.1f && chasePlayer && !onMovingPlatform) {
			if(changeDirection)
			r.AddForce (new Vector3 (75f, 150f, 0), ForceMode.Force);
			else
			r.AddForce (new Vector3 (-75f, 150f, 0), ForceMode.Force);
			
			}
	}




	void OnCollisionStay(Collision c){
		if(c.gameObject.name == "MovingPlatform"){
			onMovingPlatform = true;
		}
	}

	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Player")) {
			chasePlayer = true;
			if (c.gameObject.transform.position.x > transform.position.x)
				changeDirection = true;
			else
				changeDirection = false;
				
		}


	}

	void OnTriggerExit(Collider c){
		if(c.CompareTag("Player"))
			chasePlayer = false;
	}


}
