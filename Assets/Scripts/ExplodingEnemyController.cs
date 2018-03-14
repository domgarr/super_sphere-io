using UnityEngine;
using System.Collections;

public class ExplodingEnemyController : MonoBehaviour {
	private float blinkTimer;
	public float radius ;
	public float power;
	public GameObject explosion;

	public MeshRenderer m;
	public Material initial;
	public Material invulnerable;
	private float invulnerableTimer = 0f;

	private float explosionTimer = 0f;

	public JumpOnHeadController jc;
	private Vector3 explosionPosition;
	private Rigidbody playerRb;
	private Transform playerT;
	private Player p;

	// Use this for initialization
	void Start () {
		blinkTimer = 0f;
		explosionPosition = transform.localPosition + new Vector3(0,-1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < invulnerableTimer) {
			m.material = invulnerable;
		} else{
			m.material = initial;
			}
	
	
	
	}

	void OnTriggerStay(Collider c){
		if (Time.time > blinkTimer) {
			if (c.CompareTag ("Player")) {
				playerT = c.gameObject.GetComponent<Transform> ();
				p = c.gameObject.GetComponent<Player>();

				if (Random.Range (0, 2) == 0) {
					transform.position = playerT.position + new Vector3 (2, 0, 0);
				} else {
					transform.position = playerT.position - new Vector3 (2, 0, 0);
				}
				jc.setInvulnrablility ();
				playerRb = c.gameObject.GetComponent<Rigidbody> ();

				Invoke ("addExplosion", 1f);
				blinkTimer = Time.time + 5f;
				invulnerableTimer = Time.time + 2f;
			}
		
		}
	}

	private void addExplosion(){
		playerRb.AddExplosionForce (power,explosionPosition, radius, 10, ForceMode.Impulse);

		Instantiate (explosion, transform.position, transform.localRotation);
		float distanceBtwEnemy = Mathf.Abs (playerT.position.x - transform.position.x);
		if (distanceBtwEnemy < 3) {
			p.removeHealth (2);
		} else if (distanceBtwEnemy < 5) {
			p.removeHealth (1);
		}



	}


}
