using UnityEngine;
using System.Collections;

public class MoveWithPlayer : MonoBehaviour {
	public Transform playerPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = playerPosition.position;
	}
}
