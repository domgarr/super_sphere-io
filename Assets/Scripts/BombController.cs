using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {
	public float radius ;
	public float power;
	// Use this for initialization
	void Start () {
		Vector3 explosionPosition = transform.localPosition;
		gameObject.GetComponent<Rigidbody>().AddExplosionForce (power,explosionPosition, radius, 2, ForceMode.Impulse);


	}
	
	// Update is called once per frame
	void Update () {
	}
}
