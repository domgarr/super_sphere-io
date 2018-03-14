using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject bullet;
	public Transform gunTip;

	private float nextFire;


	private bool facing;


	private bool lockedOn;
	// Use this for initialization
	void Start () {
		nextFire = 0;
		lockedOn = false;
		facing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (1, 80) == 2 && !lockedOn) {
			transform.Rotate (new Vector3 (0, 180, 0));
			facing = !facing;

		}
	}


	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Player")) {
			if (Time.time > nextFire) {
					lockedOn = true;
				

				Instantiate (bullet, gunTip.position, transform.rotation);
				nextFire = Time.time + 2f;
			}

		}
	}

	void OnTriggerExit(Collider c){
		if (c.CompareTag ("Player")) {
			lockedOn = false;
	
		}
	}

	public bool isFacingRight(){
		return facing;
	}




}
