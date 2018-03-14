using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour {
	private bool gameState;
	private string pauseText= "Pause";
	private string runningText = "Running";
	private Text text;
	// Use this for initialization
	void Start () {
		gameState = true;
		text = gameObject.GetComponentInChildren<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if (gameState) {
			gameState = !gameState;
			text.text = pauseText;
			Time.timeScale = 0f;
		} else {
			gameState = !gameState;
			text.text = runningText;
			Time.timeScale = 1f;
		}

	}
}
