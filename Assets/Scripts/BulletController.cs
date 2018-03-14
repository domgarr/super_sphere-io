using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	private Rigidbody r;
	private PlayerController pc;
	public float speed;

	public float y;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		pc = GameObject.Find ("Player").GetComponent<PlayerController> ();

		//Note: For more accurate bullets use an invisible plane at Z = 0, and use raycasts to detect position of mouse.

		transform.position += new Vector3 (0, 0, 1);
	
		var mousePos = Input.mousePosition;
			mousePos.z =10;
			Vector3 screenPos = Camera.main.ScreenToWorldPoint (mousePos);
		
		gameObject.transform.LookAt (screenPos);

		Vector3 direction = (screenPos - transform.position).normalized;

		if (pc.getFacing()) {
			if (screenPos.x > transform.position.x)
				r.AddForce (direction*speed, ForceMode.Impulse);
			else
				Destroy (gameObject);
		} else {
			if (screenPos.x < transform.position.x)
				r.AddForce (direction*speed, ForceMode.Impulse);
			else
				Destroy (gameObject);
		}
			
	

	}		
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5f);
	}

	void OnCollisionEnter(Collision c){
		if ( c.collider.gameObject.tag == "Enemy") {
				Destroy (c.gameObject);
			Destroy (gameObject);
		}

	}
}
