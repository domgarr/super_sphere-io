using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private float totalZoneLength;
	private float zoneLength;
	public Transform player;
	// Use this for initialization
	void Start () {
		totalZoneLength = 15f;
		zoneLength = 15f;
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate(){
		
		if (player != null && player.position.x > totalZoneLength - zoneLength && player.position.x < 285f) {
			transform.position = new Vector3 (player.position.x, 10f, player.position.z - 10);
			totalZoneLength = player.position.x + zoneLength;

		}

	}
}
