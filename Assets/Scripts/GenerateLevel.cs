using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {
	public GameObject grass;
	public GameObject dirt;
	public GameObject cloud;
	public GameObject backgroundGrass;
	public GameObject backgroundHill;
	public Transform cameraPosition;

	public GameObject movingPlatform;
	public GameObject platform;
	public GameObject red;

	public GameObject coin;

	public GameObject runner;
	public GameObject shooter;
	public GameObject cubeBoss;
	public GameObject blink;

	private GameObject[] container;
	public GameObject win; 
	private int cleanUpCounter;
	private int containerCounter;

	private int dirtHeight;
	private int grassHeight;
	private int pastGrassHeight;
	private int hillMaxHeight=30;
	private int hillCurrentHeight;
	private float backgroundWidth;
	private bool apex = true;

	float nextPlatformRate;
	bool onePlatform;

	private int totalGapLength;
	private int gapLength=0;

	private int cloudWidth;
	private int rockWidth;
	private float h,w;

	private int zoneLength=60;
	private int zoneTotalLength = 60;
	private int pastZoneLength=0;

	public bool spawnBoss;

	// Use this for initialization
	void Start () {
		container = new GameObject[1000];
		containerCounter = 0;
		totalGapLength = 0;
		//zoneTotalLength += zoneLength;
	
		dirtHeight =  5;
		grassHeight = 4;
		backgroundWidth = 0;

		nextPlatformRate = 1f;
		//generateLayers ();
	}
	
	// Update is called once per frame
	void Update () {
		//Maybe put a timer on cleanUp
		//Debug.Log (cameraPosition.position.x + 15 + " --- " + pastZoneLength);
		if (cameraPosition.position.x + 15 > pastZoneLength && zoneTotalLength < 600)
			generateLayers ();
		else if (cameraPosition.position.x + 15 > pastZoneLength   && zoneTotalLength < 660) {
			addBossPlatform ();
			}
		}

	void FixedUpdate(){


	}
	//Can be refactored, and made universal
	private void generateLayers(){
		
		for (int i = containerCounter; i < zoneTotalLength; i++) {
			container [i] = new GameObject ();
			container [i].GetComponent<Transform> ().position = new Vector3 (w, 0, 0);
			container [i].AddComponent<DestroyMe> ();
			h=0.0f;

			if (Random.Range (0, 100) == 1) {
				gapLength = Random.Range (6, 11) * 2; 
				onePlatform = true;
			}


			if ( gapLength > 0 && containerCounter > 10) {

				if (onePlatform == true) {
					Instantiate (movingPlatform, new Vector3 (w + gapLength / 4, grassHeight + Random.Range(2,5), 0), transform.localRotation);
					onePlatform = false;
				}

				addBackgroundGrass (i);
				addBackgroundHills (i);

				addCoin (i);

				if (Random.Range (1, 15) == 1) {
					cloudWidth = Random.Range (10, 21);
					//Set intitial random height;

				}
				if (cloudWidth > 0) {
					addCloud (i);
					cloudWidth--;
				}
				gapLength--;

			} else {

				addDirt (i);
				smoothGrass ();
				addGrass (i);
				addBackgroundGrass (i);
				addBackgroundHills (i);
				if (Random.Range (1, 50) == 1 && containerCounter > 10)
					rockWidth = Random.Range (5, 10);

				if (rockWidth > 0) {
					addRock (i);
					rockWidth--;
				}



				if (Random.Range (1, 15) == 1 && Time.time > nextPlatformRate && containerCounter > 10) {
					Instantiate (platform, new Vector3 (w, grassHeight + Random.Range (4, 6), 0), transform.localRotation);
					nextPlatformRate = Time.time + 1f;
				} else {
					addEnemy (i);
					addCoin (i);
				}


				if (Random.Range (1, 15) == 1) {
					cloudWidth = Random.Range (10, 21);
					//Set intitial random height;

				}
				if (cloudWidth > 0) {
					addCloud (i);
					cloudWidth--;
				}

			}
			w += dirt.transform.localScale.x;
			backgroundWidth += 0.5f;

		}

		pastZoneLength += zoneLength/2;
		zoneTotalLength += zoneLength;
		containerCounter += zoneLength;
	}


	private void addDirt(int i){
		for (int j = 0; j < dirtHeight; j++) {
			Instantiate (dirt, new Vector3 (w, h, 0), transform.localRotation, container [i].transform);
			h += dirt.transform.localScale.y;
		}
		h -= 0.25f;
	}

	private void addGrass(int i){
		for (int k = 0; k < grassHeight; k++) {
			Instantiate (grass,new Vector3 (w, h, 0), transform.localRotation, container [i].transform);
			h += grass.transform.localScale.y;
		}
	}

	private void smoothGrass(){
		int i = Random.Range (1 , 4);

		if (i == 1 && grassHeight < 4 && pastGrassHeight != 1)
			grassHeight++;
		else if (i == 2 && grassHeight > 1 && pastGrassHeight !=2)
			grassHeight--;

		pastGrassHeight = i;
	}

	private void addRock(int containerNumber){
		float rockHeight = Random.Range (1, 4);
		for(int i = 0; i < rockHeight ; i++){
			Instantiate(red, new Vector3 (w, h, 0), transform.localRotation, container [containerNumber].transform);
			h += 0.5f;
			}
		}



	private void addCloud(int containerNumber){
		float cloudHeight = Random.Range (5, 10);

		//int v= Random.Range (5, 9);


				for (int l = 0; l < cloudHeight; l++) {
			Instantiate (cloud, new Vector3(w, h + Random.Range (5, 9), Random.Range(10,14)), transform.localRotation, container[containerNumber].transform);
			h += 0.50f;
		}
	}

	private void addCoin(int i){
		if (Random.Range (1, 150) == 1) {
			Instantiate (coin, new Vector3 (w, grassHeight+Random.Range(1,4), 0), transform.localRotation, container[i].transform);
		}
	}

	private void addEnemy(int i){
		//Prevent monsters spawning at starting area
		if (containerCounter > 10) {
			if (Random.Range (1, 150) == 1) {
				Instantiate (runner, new Vector3 (w, grassHeight + 3, 0), transform.localRotation);
			}

			if (Random.Range (1, 200) == 1) {
				Instantiate (shooter, new Vector3 (w, grassHeight + 3, 0), transform.localRotation);
			}
		}
	}


	private void addBossPlatform(){
		for (int i = containerCounter; i < zoneTotalLength; i++) {
			container [i] = new GameObject ();
			container [i].GetComponent<Transform> ().position = new Vector3 (w, 0, 0);
			container [i].AddComponent<DestroyMe> ();

			h=0.0f;

			addDirt (i);
			smoothGrass ();
			addGrass (i);

			addBackgroundGrass (i);
			addBackgroundHills (i);

			addCoin (i);

			if (Random.Range (1, 15) == 1) {
				cloudWidth = Random.Range (10, 21);
				//Set intitial random height;

			}
			if (cloudWidth > 0) {
				addCloud (i);
				cloudWidth--;
			}
			backgroundWidth += 0.5f;
			w += dirt.transform.localScale.x;

		}
		if (spawnBoss) {
			Instantiate (cubeBoss, new Vector3 (w -5, grassHeight + 2, 0), transform.localRotation);
			Instantiate (blink, new Vector3 (w - 25, grassHeight + 7, 0), transform.localRotation);
			Instantiate (blink, new Vector3 (w - 5, grassHeight + 7, 0), transform.localRotation);
		}
			else
			spawnWin ();

		pastZoneLength += zoneLength/2;

		zoneTotalLength += zoneLength;
		containerCounter += zoneLength;
	}

	private void addBackgroundGrass(int i){
		float z = 0;
		for (int j = 0; j < 5; j++) {
			Instantiate (backgroundGrass, new Vector3 (backgroundWidth,2f, z+1.5f), transform.localRotation, container [i].transform);
			z += grass.transform.localScale.z;
		}
	}

	private void addBackgroundHills(int i ){
		if (hillCurrentHeight < hillMaxHeight / 2 && apex == true){
			hillCurrentHeight += Random.Range (0, 2);
		}
		else{
			apex= false;
			hillCurrentHeight -= Random.Range (0, 2);
			if (hillCurrentHeight <= 0) {
				hillCurrentHeight++;
				apex = true;
			}
		}
		float height = 0f;
		for(int j = 0; j < hillCurrentHeight ; j++){
			Instantiate (backgroundHill, new Vector3 (backgroundWidth, height+2, 4), transform.localRotation, container [i].transform);
			height += 0.5f;
		}

		}

	public void spawnWin(){
		Instantiate (win, new Vector3 (w - 15, grassHeight + 5, 0), transform.localRotation);
	}


}
