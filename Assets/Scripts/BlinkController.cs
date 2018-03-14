using UnityEngine;
using System.Collections;

public class BlinkController : MonoBehaviour {
	private int blinkCounter;
	private Transform player;
	private Vector3 screenPos;
	private float blinkCooldown;
	private PlayerController pc;
	private bool blinked;
	// Use this for initialization

	void Awake(){
	}

	void Start () {
		blinkCounter = 6;
		player = GameObject.Find ("Player").GetComponent<Transform> ();
		pc = GameObject.Find ("Player").GetComponent<PlayerController> ();
		Invoke ("activateUI", 0.25f);
		Destroy (gameObject, 30f);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10f;

		screenPos = Camera.main.ScreenToWorldPoint (mousePos);


		if (blinkCounter > 1 && Input.GetMouseButton(0) && Time.time > blinkCooldown) {
			player.position = new Vector3(screenPos.x, screenPos.y,0f);
			blinkCounter--;
			removeCharge ();
			blinkCooldown = Time.time + 2f;
			blinked = true;

		}

		if (blinkCounter <= 1) {
			GameObject.Find ("Player").GetComponent<PlayerController> ().setDefaultSkin ();
			Destroy (gameObject);
		}
	
	}

	void OnDestroy(){
		deActivateUI ();
		//Invoke ("deActivateUI", 0.01f);
	}

	public void setBlink(bool b){
		blinked = b;
	}

	public bool isBlinking(){
		return blinked;
	}

	private void activateUI(){



		for (int i = 1; i <= 5; i++) {
			GameObject.Find ("BlinkCount" + i).gameObject.GetComponent<MeshRenderer> ().enabled = true;		
		}
	}

	public void deActivateUI(){
		
		for (int i = 1; i <= 5; i++) {
			GameObject.Find ("BlinkCount" + i).gameObject.GetComponent<MeshRenderer> ().enabled = false;		

		}
	}

	private void removeCharge(){
		
		GameObject.Find ("BlinkCount" + blinkCounter).gameObject.GetComponent<MeshRenderer>().enabled = false;
	}


}
