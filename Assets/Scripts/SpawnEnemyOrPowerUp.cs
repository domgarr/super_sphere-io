using UnityEngine;
using System.Collections;

public class SpawnEnemyOrPowerUp : MonoBehaviour {
	public GameObject runner;
	public GameObject shooter;
	public GameObject bomber;
	public GameObject ice;
	public GameObject desert;

	public GameObject shield;
	public GameObject beam;
	public GameObject gun;
	public GameObject blink;
	public GameObject sword;
	public GameObject coin;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getPowerUp(){
		int i = Random.Range (0, 36);

		if (i <= 10) {
			return coin;
		} else if (i > 10 && i <= 15) {
			return beam;
		} else if (i > 15 && i <= 20) {
			return gun;
		} else if (i > 20 && i <= 25) {
			return blink;
		} else if (i > 25 && i <= 30) {
			return sword;
		} else if (i > 30 && i <= 35) {
			return shield;
		}
		return null;
	}

	public GameObject getEnemy(){
		int i = Random.Range (0, 31);
	
		if (i <= 10) {
			return runner;
		} else if (i > 10 && i <= 15) {
			return shooter;
		}else if (i > 15 && i <= 20) {
			return bomber;
		}else if (i > 20 && i <= 25) {
			return desert;
		}else if (i > 25 && i <= 30) {
			return ice;
		}

		Debug.Log (i);
		return null;
	}

	public GameObject getBoth(){
		if(Random.Range(0,2) == 1){
			return getEnemy();
		} else {
			return getPowerUp();
			}
	}

}
