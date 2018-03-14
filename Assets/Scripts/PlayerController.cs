using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float runSpeed;
	public float jump;
	public Transform playerOrientation;
	public Material original;
	public Material blue;
	public Material purple;

	public GameObject laserBeam;
	public GameObject sword;

	public Player player;

	public GameObject machineGun;
	public GameObject projectile;
	public Transform bulletPosition;
	public GameObject blink;

	private Rigidbody cubeRigidBody;



	private bool canJump;
	private bool canDoubleJump;
	private float doubleJumpTimer;

	private float runningSpeed;

	private bool hasBeam = false;
	private float beamTimer;
	private float beamRate;

	private float shieldTimer;

	private bool hasGun = false;
	private float gunTimer;
	private float nextFireRate = 0f;

	private bool hasBlink = false;
	private float blinkTimer=0f;
	private BlinkController bc;
	private GameObject temporaryBlink;

	private bool hasSword = false;
	private float swordRate = 0f;
	private float swordTimer = 0f;

	private bool facingRight = true;



	// Use this for initialization
	void Start () {
		cubeRigidBody = GetComponent<Rigidbody>();
		bc = blink.GetComponent<BlinkController> ();
		canJump = false;
		canDoubleJump = false;

	}
	
	// Update is called once per frame
	void Update () {



		if ((Input.GetKey (KeyCode.Space) && canJump) || ((bc.isBlinking() && Input.GetKey (KeyCode.Space)))) {
			executeJump ();
			canDoubleJump = true;
			doubleJumpTimer = Time.time + 0.2f;
			bc.setBlink (false);


		}
		if (!canJump && Time.time > doubleJumpTimer) {
			if (Input.GetKey (KeyCode.Space) && canDoubleJump) {
				
				executeDoubleJump();
				canDoubleJump = false;
			}
		}

		if (hasBeam) {
			
			if(Input.GetMouseButton (0) && Time.time > beamRate){
				if ( beamTimer > Time.time) {
					Instantiate (laserBeam, playerOrientation.position , Quaternion.Euler (0, 0, 90));
					GetComponent<Animator> ().SetTrigger ("isBeaming");
					beamRate = Time.time + 1f;
				}

			}


		}

		if (shieldTimer < Time.time) {
			player.deActivateShield ();
			GameObject.Find ("ShieldBubble").gameObject.GetComponent<MeshRenderer>().enabled = false;
		}

		if (hasGun && gunTimer > Time.time && Input.GetMouseButton (0)) {
			if (Time.time > nextFireRate) {
				Instantiate (projectile, bulletPosition.position, bulletPosition.rotation);
				nextFireRate = Time.time + 0.25f;
			}
		}
	
		if (hasBlink && Time.time > blinkTimer) {
			
			hasBlink = false;
		}

		if (hasSword && Time.time < swordTimer) {
			if (Input.GetMouseButton (0) && Time.time > swordRate) {
				GameObject.Find("PlayerSword").GetComponent<Animator> ().SetTrigger ("SwordSlash");
				swordRate = Time.time + 0.5f;
			}
		}

		if (Time.time > swordTimer) {
			sword.SetActive (false);
		}

		if (Time.time > gunTimer ) {
			machineGun.SetActive (false);
		}

		if (Time.time > blinkTimer) {
			Destroy (temporaryBlink);
		}

		if (Time.time > beamTimer && !hasBlink ) {
			setDefaultSkin ();
		}
	}

	void FixedUpdate(){
		runningSpeed = 0;
		if (Input.GetKey (KeyCode.LeftControl))
			runningSpeed = runSpeed;
		if (Input.GetKey (KeyCode.D)) {
			cubeRigidBody.AddForce (new Vector3 (1, 0, 0).normalized * (speed + runningSpeed), ForceMode.Force);
			facingRight = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			cubeRigidBody.AddForce (new Vector3 (-1, 0, 0).normalized * (speed + runningSpeed), ForceMode.Force);
			facingRight = false;
		}
		
	
	}
		


	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Ground")) {
			canJump = true;
		}
	

	
	}

	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Ground")) {
			canJump = true;
		}

	}

	void OnTriggerExit(Collider c){
		if (c.CompareTag ("Ground")) {
			canJump = false;
		}
	}

	public void pickupPowerUp(string powerup){
		resetPowerUps ();
		if (powerup.Equals ("BeamPowerup(Clone)")) {
			hasBeam = true;
			gameObject.GetComponent<MeshRenderer>().material = blue;
			beamTimer = Time.time + 30f;
		} else if (powerup.Equals ("Shield(Clone)")) {
			GameObject.Find ("ShieldBubble").gameObject.GetComponent<MeshRenderer> ().enabled = true;
			player.activateShield ();
			shieldTimer = Time.time + 30f;
		} else if (powerup.Equals ("MachineGun(Clone)")) {
			hasGun = true;
			machineGun.SetActive (true);
			gunTimer = Time.time + 30f;
		}else if(powerup.Equals("Blink(Clone)")){
			GameObject temporaryBlink =(GameObject) Instantiate (blink, transform.position, transform.localRotation);

			hasBlink = true;
			gameObject.GetComponent<MeshRenderer>().material = purple;
			blinkTimer = Time.time + 30f;
		}else if(powerup.Equals("SwordObjectPowerUp(Clone)")){
			hasSword = true;
			sword.SetActive (true);
			swordTimer = Time.time +  30f;
		}
	}
	//IF true, player is facing right
	public bool getFacing(){
		return facingRight;
	}

	public void resetJump(){
		canJump = true;
	}

	private void resetPowerUps(){
		
		if(GameObject.Find ("BlinkObject(Clone)") != null)
			Destroy (GameObject.Find ("BlinkObject(Clone)").gameObject);
	
		machineGun.SetActive (false);
		sword.SetActive (false);
		blink.GetComponent<BlinkController> ().deActivateUI ();
		hasBeam = false;
		hasGun = false;
		hasBlink = false;
		hasSword = false;

		gunTimer = 0f;
		beamTimer = 0f;
		blinkTimer = 0f;
		shieldTimer = 0f;
		swordTimer = 0f;
	}

	private void executeJump(){
		
		Vector3 jumpHeight = cubeRigidBody.velocity;
		jumpHeight.y = 75f;
		GetComponent<Animator> ().SetTrigger ("isJumping");
		cubeRigidBody.velocity = jumpHeight;


	//cubeRigidBody.AddForce(new Vector3(0,100f,0),ForceMode.Impulse);
	}

	private void executeDoubleJump(){
		cubeRigidBody.AddForce(new Vector3(0,100f,0),ForceMode.Impulse);
	}

	public void setDefaultSkin(){
		gameObject.GetComponent<MeshRenderer>().material = original;
	}





	void OnDestroy (){
		Destroy (sword);
		Destroy (machineGun);
	}
}
