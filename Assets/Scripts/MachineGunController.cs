using UnityEngine;
using System.Collections;

public class MachineGunController : MonoBehaviour {
	public Transform player;
	private Quaternion gunRotation;
	private Vector3 gunPosition;
	private PlayerController pc;
	// Use this for initialization
	void Start () {
		pc = GameObject.Find ("Player").GetComponent<PlayerController> ();
		gunRotation = transform.rotation;
		gunPosition =  new Vector3(1.5f,0.5f,-1);
	}

	// Update is called once per frame
	void Update () {

		if (!pc.getFacing()) {
			gunPosition =  new Vector3(-1.5f,0.5f,-1);
			gunRotation = Quaternion.Euler (new Vector3 (0, -180, 0));
		} else {
			gunPosition =  new Vector3(1.5f,0.5f,-1);
			gunRotation = Quaternion.Euler (new Vector3 (0, 0, 0));

		}




	}

	void LateUpdate(){
		transform.position = player.position + gunPosition;
		transform.rotation = gunRotation;

	}


}
