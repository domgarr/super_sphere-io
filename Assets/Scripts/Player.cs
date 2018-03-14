using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public GameObject hearts;
	public GameObject tryAgainButton;
	public GameObject bloodSplatter;
	public bool untouchable;


	private Component[] aHearts;
	private int playerHealth;
	private int coins;
	private int enemyCount;

	private float playerInvulnerabiltyTimer = 0f;
	private bool canDamage;

	private bool isShieldPowerUpActive = false;

	private string loseText = "Game Over!";
	private string winText = "Complete!";

	// Use this for initialization
	void Start () {
		playerHealth = 3;
		coins = 0;
		enemyCount = 0;
		aHearts = hearts.GetComponentsInChildren<Transform> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		

		if (playerHealth <= 0) {
			deathScreen ();

		}
	}

	void addHealth(int n){
		playerHealth += n;
	}

	public void removeHealth(int n){
		if (!isShieldPowerUpActive  && Time.time > playerInvulnerabiltyTimer && !untouchable) {
			Instantiate (bloodSplatter, transform.position, transform.localRotation);
			for (int i = 0; i < n; i++) { 
				GameObject.Find ("Heart" + playerHealth).SetActive (false);
				playerHealth --;

			}
			playerInvulnerabiltyTimer = Time.time + 1f;
		}

	}

	public void addCoins(int n){
		coins += n;
		GameObject.Find ("CoinText").GetComponent<Text> ().text = "" + coins;

	}

	public void deathScreen(){
		Destroy (gameObject.GetComponent<MeshRenderer> ());

		Time.timeScale = 0;
		GameObject.Find ("PauseButton").GetComponent<Button> ().enabled = false;
		GameObject.Find ("GameOverText").GetComponent<Text> ().enabled = true;
		GameObject.Find ("GameOverText").GetComponent<Text> ().text = loseText;
		tryAgainButton.SetActive (true);
		PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") + coins);
		PlayerPrefs.SetInt ("EnemiesKilled", PlayerPrefs.GetInt ("EnemiesKilled") + enemyCount);
		Destroy(GameObject.Find("PlayerOrientation").gameObject);
		Destroy(gameObject);
	}

	public void winScreen(){
		Time.timeScale = 0;
		GameObject.Find ("PauseButton").GetComponent<Button> ().enabled = false;
		PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") + coins);
		PlayerPrefs.SetInt ("EnemiesKilled", PlayerPrefs.GetInt ("EnemiesKilled") + enemyCount);
		GameObject.Find ("GameOverText").GetComponent<Text> ().enabled = true;
		GameObject.Find ("GameOverText").GetComponent<Text> ().text = winText;
		tryAgainButton.SetActive (true);
		}


	public void activateShield(){
		isShieldPowerUpActive = true;
	}

	public void deActivateShield(){
		isShieldPowerUpActive = false;
	}

	public void addEnemyCount(){
		enemyCount++;
		GameObject.Find ("EnemyKilled").GetComponent<Text> ().text = "" + enemyCount;
	}



}
