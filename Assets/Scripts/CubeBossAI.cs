using UnityEngine;
using System.Collections;

public class CubeBossAI : MonoBehaviour {
	private Rigidbody r;

	private bool bossJumped;
	private float bossJumpCooldown = 0f;
	private float jumpPosition;
	private Vector3 jumpHeight;
	GameObject win;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		bossJumped = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Player"))
			bossAI (c);
				
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.CompareTag ("Player")) {
			Rigidbody rb = c.gameObject.GetComponent<Rigidbody> ();
			if (Random.Range (1, 2) == 1)
				rb.AddForce (new Vector3 (100f, 5f, 0f), ForceMode.Impulse);
			else
				rb.AddForce (new Vector3 (-100f, 5f, 0f), ForceMode.Impulse);

			r.velocity = Vector3.zero;
			GameObject.Find("Player").gameObject.GetComponent<Player> ().removeHealth (1);
		} else if(bossJumped){
			
			Destroy (c.gameObject);
			Invoke ("setBossJumpFalse",0.2f);
		}


	}

		private void bossAI(Collider c){
		jumpPosition =  c.gameObject.transform.position.x - transform.position.x;


		if (Random.Range (1, 75) == 1  && !bossJumped && Time.time > bossJumpCooldown) {
			jumpHeight = r.velocity;
			jumpHeight.y = 75f;
			r.velocity = jumpHeight;
			if (c.transform.position.x > transform.position.x) {
				if (c.transform.position.y > transform.position.y) {
					r.AddForce (new Vector3 (jumpPosition * 12, 0f, 0f), ForceMode.Impulse);	
				}else
					r.AddForce (new Vector3 (jumpPosition*4 ,0f, 0f), ForceMode.Impulse);
				

				bossJumped = true;
			} else {

				if(c.transform.position.y > transform.position.y)
					r.AddForce (new Vector3 (jumpPosition*12 , 0f, 0f), ForceMode.Impulse);
				else
					r.AddForce (new Vector3 (jumpPosition*4 , 0f, 0f), ForceMode.Impulse);

				bossJumped = true;
				bossJumpCooldown = Time.time + 0.5f;
			}
		}



		}		

	private void setBossJumpFalse(){
		bossJumped = false;
	}

	void OnDestroy(){
		GameObject.Find("LevelGenerator").GetComponent<GenerateLevel>().spawnWin();
	}

}