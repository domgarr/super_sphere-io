using UnityEngine;
using System.Collections;

public class inflictDamage : MonoBehaviour {
	float invulnerableTimer;
	float invulnerableRate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider c){
		if(Time.time > invulnerableTimer ){
		if (c.CompareTag ("Player")) {
				GameObject.Find("Player").GetComponent<Player> ().removeHealth (1);
				invulnerableTimer = Time.time + invulnerableRate;
		}
		}
		}
}
