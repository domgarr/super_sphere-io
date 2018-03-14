using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPlayerPrefs : MonoBehaviour {
	public Text coins;
	public Text enemiesKilled;
	// Use this for initialization
	void Start () {
		coins.text = "" + PlayerPrefs.GetInt ("Money");
		enemiesKilled.text = "" + PlayerPrefs.GetInt ("EnemiesKilled");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
