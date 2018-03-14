using UnityEngine;
using System.Collections;

public class MoneyController : MonoBehaviour {
	private bool untouched;
	// Use this for initialization
	void Start () {
		untouched = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player") && untouched) {
			untouched = true;
			GameObject.Find("Player").GetComponent<Player> ().addCoins (1);
			Destroy(gameObject);
		}

	}
}
