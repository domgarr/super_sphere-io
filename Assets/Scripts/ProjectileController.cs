using UnityEngine;
using System.Collections;


public class ProjectileController : MonoBehaviour {
	
	public float projectileSpeed;
	public float projectileY;
	private float lifeTime;
	private Transform player;
	// Use this for initialization
	void Start () {
		

		lifeTime = Time.time + 5;

		player = GameObject.Find ("Player").GetComponent<Transform> ();

		Vector3 direction = ( player.position - transform.position + new Vector3(0,5,0)).normalized;

		if (player.position.x < transform.position.x)
			gameObject.GetComponent<Rigidbody>().AddForce (direction  * projectileSpeed , ForceMode.Impulse);
		else
			gameObject.GetComponent<Rigidbody>().AddForce (direction * projectileSpeed , ForceMode.Impulse);

	}
	//+ new Vector3(0,projectileY,0)
	// Update is called once per frame

	void Update(){
		
		

		if (Time.time > lifeTime)
			Destroy(gameObject);


	}

	void OnCollisionEnter(){
		
	
		Destroy (gameObject.GetComponent<inflictDamage> ());
	}


}
