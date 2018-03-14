using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void OnClick() {
		if(gameObject.name.Equals("MainMenuButton"))
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		else if(gameObject.name.Equals("PlainsButton"))
			UnityEngine.SceneManagement.SceneManager.LoadScene("Plains");
		else if(gameObject.name.Equals("DesertButton"))
			UnityEngine.SceneManagement.SceneManager.LoadScene("Desert");
		else if(gameObject.name.Equals("CaveButton"))
			UnityEngine.SceneManagement.SceneManager.LoadScene("FrozenCave");
		else if(gameObject.name.Equals("ControlButton"))
	UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
	}
}
