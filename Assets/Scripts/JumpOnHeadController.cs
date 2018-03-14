using UnityEngine;
using System.Collections;

public class JumpOnHeadController : MonoBehaviour {
	private bool invulnerable;
	private float invulnerableTimer = 0f;
	private Player p;
	// Use this for initialization
	void Start () {
		p = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time > invulnerableTimer) {
			gameObject.GetComponentInParent<BoxCollider> ().enabled = true;
			invulnerable = false;

		}
	}


	void OnCollisionEnter(Collision c){
		if(c.gameObject.CompareTag("MeleeWeapon") && Input.GetMouseButton (0) ||c.gameObject.CompareTag("Projectile") ){
			Destroy (transform.parent.gameObject);
			p.addEnemyCount ();

		}
	}

	void OnTriggerEnter(Collider c){
		

		if (!invulnerable) {
			if (c.CompareTag ("Player") || c.gameObject.CompareTag("MeleeWeapon") && Input.GetMouseButton (0) || c.gameObject.CompareTag("Projectile") ) {
				//Destroy (gameObject.transform.root.gameObject);
				Destroy (transform.parent.gameObject);
				p.addEnemyCount ();
			}
		}
	}

	public void setInvulnrablility(){
		invulnerable = true;
		invulnerableTimer = Time.time + 2f;

		gameObject.GetComponentInParent<BoxCollider> ().enabled = false;

		
	}
}
