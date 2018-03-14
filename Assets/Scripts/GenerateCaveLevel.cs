using UnityEngine;
using System.Collections;

public class GenerateCaveLevel : MonoBehaviour {
	public GameObject ice;
	public GameObject caveDirt;
	public GameObject backgroundCave;
	public GameObject ceiling;
	public Transform cameraPosition;

	public GameObject movingPlatform;
	public GameObject platform;
	public GameObject red;

	public GameObject coin;

	public GameObject runner;
	public GameObject shooter;
	public GameObject cubeBoss;
	public GameObject win;
	private GameObject[] container;
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

	private int totalGapLength=0;

	private int cloudWidth;
	private int rockWidth;
	private float h,w;

	private int zoneLength=60;
	private int zoneTotalLength = 60;
	private int pastZoneLength=0;

	private int stalagmiteWidth;
	public GameObject stalagmite;

	private int ceilingHeight;
	private int pastCeilingHeight;

	private int gapLength;
	private bool onePlatform;

	public bool spawnBoss;

	// Use this for initialization
	void Start () {
		container = new GameObject[1000];
		containerCounter = 0;

		dirtHeight =  5;
		grassHeight = 4;
		ceilingHeight = 4;
		backgroundWidth = 0;

		nextPlatformRate = 1f;
	}
	
	// Update is called once per frame
	void Update () {

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
				//addGap (i);

				if (onePlatform == true) {
					Instantiate (movingPlatform, new Vector3 (w + gapLength / 4, grassHeight + 2, 0), transform.localRotation);
					onePlatform = false;
				}

				addBackgroundGrass (i);

				addCoin (i);

				h += 15;
				addCeiling (i);
				if (Random.Range (1, 20) == 1 ) 
					stalagmiteWidth = Random.Range (5, 10);

				if (stalagmiteWidth > 0) {
					addStalagmite (i);
					stalagmiteWidth--;
				}

			
				gapLength--;

			} else {

				addDirt (i);
				smoothGrass ();
				addGrass (i);
				addBackgroundGrass (i);
				if (Random.Range (1, 50) == 1 && containerCounter > 10)
					rockWidth = Random.Range (5, 10);

				if (rockWidth > 0) {
					addRock (i);
					rockWidth--;
				}

				addEnemy (i);
				addCoin (i);

				if (Random.Range (1, 15) == 1 && Time.time > nextPlatformRate && containerCounter > 10) {
					Instantiate (platform, new Vector3 (w, grassHeight + Random.Range (3, 5), 0), transform.localRotation);
					nextPlatformRate = Time.time + 1f;
				}

				h += 12;
				addCeiling (i);
				if (Random.Range (1, 20) == 1 ) 
					stalagmiteWidth = Random.Range (5, 10);

				if (stalagmiteWidth > 0) {
					addStalagmite (i);
					stalagmiteWidth--;
				}

			}
			w += caveDirt.transform.localScale.x;
			backgroundWidth += 0.5f;

		}

		pastZoneLength += zoneLength/2;
		zoneTotalLength += zoneLength;
		containerCounter += zoneLength;
	}


	private void addDirt(int i){
		for (int j = 0; j < dirtHeight; j++) {
			Instantiate (caveDirt, new Vector3 (w, h, 0), transform.localRotation, container [i].transform);
			h += caveDirt.transform.localScale.y;
		}
		h -= 0.25f;
	}

	private void addGrass(int i){
		
		for (int k = 0; k < grassHeight; k++) {
			Instantiate (ice,new Vector3 (w, h, 0), transform.localRotation, container [i].transform);
			h += ice.transform.localScale.y;
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




	private void addCoin(int i){
		if (Random.Range (1, 150) == 1) {
			Instantiate (coin, new Vector3 (w, grassHeight+3, 0), transform.localRotation, container[i].transform);
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

			h += 12;
			addCeiling (i);
			if (Random.Range (1, 20) == 1 ) 
				stalagmiteWidth = Random.Range (5, 10);

			if (stalagmiteWidth > 0) {
				addStalagmite (i);
				stalagmiteWidth--;
			}

			w += caveDirt.transform.localScale.x;

		}
		if (spawnBoss)
			Instantiate (cubeBoss, new Vector3 (w - 15, grassHeight + 5, 0), transform.localRotation);
		else
			spawnWin ();



		pastZoneLength += zoneLength/2;

		zoneTotalLength += zoneLength;
		containerCounter += zoneLength;
	}

	private void addBackgroundGrass(int i){
		float z = 0;
		for (int j = 0; j < 5; j++) {
			Instantiate (backgroundCave, new Vector3 (backgroundWidth,2f, z+1.5f), transform.localRotation, container [i].transform);
			z += ice.transform.localScale.z;
		}
	}




	private void addCeiling(int i){
		for (int j = 0; j < dirtHeight; j++) {
			Instantiate (ceiling, new Vector3 (w, h, 0), transform.localRotation, container [i].transform);
			h -= caveDirt.transform.localScale.y;
		}

	}

	private void addCeilingOverGap(int i){
		h = 15;
		for (int j = 0; j < ceilingHeight; j++) {
			Instantiate (ceiling, new Vector3 (backgroundWidth, h, 0), transform.localRotation, container [i].transform);
			h -= caveDirt.transform.localScale.y;
		}

	}

	private void addStalagmite(int containerNumber){
		float rockHeight = Random.Range (2, 6);
		for(int i = 0; i < rockHeight ; i++){
			Instantiate(stalagmite, new Vector3 (w, h, 0), transform.localRotation, container [containerNumber].transform);
			h -= 0.5f;
		}
	}

	private void smoothCeilingOverGap(){
		int i = Random.Range (1 , 4);

		if (i == 1 && ceilingHeight < 4 && pastCeilingHeight != 1)
			ceilingHeight++;
		else if (i == 2 && ceilingHeight > 1 && pastCeilingHeight !=2)
			ceilingHeight--;


}

	public void spawnWin(){
		Instantiate (win, new Vector3 (w - 15, grassHeight + 5, 0), transform.localRotation);
	}
}
