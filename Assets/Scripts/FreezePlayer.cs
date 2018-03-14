using UnityEngine;
using System.Collections;

public class FreezePlayer : MonoBehaviour {
	private GameObject p;
	// Use this for initialization
	void Start () {
		p = GameObject.Find ("Player");
		p.GetComponent<Rigidbody> ().mass = 10f;

		Destroy (this, 2f);
	}
		
	void OnDestroy(){
		p.GetComponent<Rigidbody> ().mass = 1f;


	}

}