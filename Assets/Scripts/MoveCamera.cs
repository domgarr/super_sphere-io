using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Awake(){
		Time.timeScale = 1f;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
  
		if(transform.position.x < (285 ))
			transform.Translate(new Vector3 (1f, 0f, 0f)*(5*Time.deltaTime));
	}


}
