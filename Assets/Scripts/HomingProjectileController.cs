using UnityEngine;
using System.Collections;


public class HomingProjectileController : MonoBehaviour {
	
	public float projectileSpeed;
	public float projectileY;
	private float lifeTime;
	private Transform player;
	public GameObject freeze;
	// Use this for initialization
	void Start () {
		projectileSpeed = 40f;

		lifeTime = Time.time + 5;

		player = GameObject.Find ("Player").GetComponent<Transform> ();


	}
	
	// Update is called once per frame
	void Update () {
		



	}

	void FixedUpdate(){
		if (player.position.x < transform.position.x)
			gameObject.GetComponent<Rigidbody>().AddForce ((player.position - transform.position) + new Vector3(0,projectileY,0) * projectileSpeed, ForceMode.Force);
		else
			gameObject.GetComponent<Rigidbody>().AddForce ((player.position - transform.position) + new Vector3(0,projectileY,0) * projectileSpeed , ForceMode.Force);
		

		if (Time.time > lifeTime)
			Destroy(gameObject);


	}

	void OnCollisionEnter(){
		Destroy (gameObject);
		Destroy (gameObject.GetComponent<inflictDamage> ());
	}

	void OnTriggerEnter(Collider c){
		if(c.CompareTag("Player"))
			Instantiate (freeze, transform.position, transform.localRotation, c.gameObject.transform);
	}

}
