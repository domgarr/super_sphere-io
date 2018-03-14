using UnityEngine;
using System.Collections;

public class GenerateGround : MonoBehaviour {
	public Transform playerPosition;
	public GameObject platform;

	//public Transform currentZone;
	//private Transform pastZone;
	public Transform currentZone;
	private Transform pastZone;


	private bool exitZoneCheck;

	// Use this for initialization
	void Start () {
		exitZoneCheck = true;
		currentZone = (Transform) Instantiate (currentZone, new Vector3 (playerPosition.position.x + 7, 0, 0), transform.localRotation);
		Instantiate (platform, new Vector3 (0, 0, 0), transform.localRotation, currentZone);

	}
	
	//Create a empty object on runtime, and set the instantiated platform as the child
	//after a a distan
	void Update () {
		if (Mathf.FloorToInt (playerPosition.position.x) % 7 == 0 && exitZoneCheck) {
			pastZone = currentZone;
			currentZone = (Transform) Instantiate(currentZone, new Vector3 (playerPosition.position.x + 7, 0, 0), transform.localRotation);
			Instantiate (platform, new Vector3 (playerPosition.position.x + 7, 0, 0), transform.localRotation, currentZone);
			Destroy(pastZone.gameObject);
			exitZoneCheck = false;
		}

		if (Mathf.FloorToInt (playerPosition.position.x) % 7 > 1)
			exitZoneCheck = true;



	}
}
