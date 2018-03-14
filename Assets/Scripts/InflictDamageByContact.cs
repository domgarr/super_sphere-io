using UnityEngine;
using System.Collections;

public class InflictDamageByContact : MonoBehaviour {
	float invulnerableTimer;
	float invulnerableRate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c){
		if(Time.time > invulnerableTimer ){
			if (c.gameObject.name == "Player") {
				c.gameObject.GetComponent<Player> ().removeHealth (1);
				invulnerableTimer = Time.time + invulnerableRate;
				Destroy (gameObject);
			}
		}
	}
}
