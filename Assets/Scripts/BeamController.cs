using UnityEngine;
using System.Collections;

public class BeamController : MonoBehaviour {
	private Transform playerPosition;
	public float offset;
	// Use this for initialization
	void Start () {
		playerPosition = GameObject.Find ("PlayerOrientation").GetComponent<Transform> (); 

		var mousePos = Input.mousePosition;
		//Since input.mousePosition does have a z axis.
		mousePos.z = 10f;

		Vector3 screenPos = Camera.main.ScreenToWorldPoint (mousePos);

		//float angle = Vector3.Angle(playerPosition.position, screenPos);
		//Calculate angle in degrees from player and mousePosition.
		float angle = Mathf.Atan2(screenPos.y - playerPosition.position.y, screenPos.x - playerPosition.position.x)*180/Mathf.PI;


		transform.rotation = Quaternion.Euler(new Vector3(0,0,angle + 90f));
		// http://answers.unity3d.com/questions/1089442/how-to-limit-mouseposition-based-on-distance-2d.html
		//Limit the mousePosition on x and y.

		Vector3 difference = screenPos - playerPosition.position;

		difference.y = Mathf.Min (5f, difference.y);
		difference.x = Mathf.Min (6f, difference.x);

		float radius  = 6f;
		difference = Vector3.ClampMagnitude (difference, radius);
		transform.position = transform.position + difference;

		Destroy (gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollision(Collider c){
		if(c.CompareTag("Enemy")){
			Destroy(c.gameObject);
		}
	}
}
