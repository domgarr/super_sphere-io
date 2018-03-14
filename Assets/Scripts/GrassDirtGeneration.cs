using UnityEngine;
using System.Collections;

public class GrassDirtGeneration : MonoBehaviour {

	public Transform playerPosition;

	public GameObject grass;
	public GameObject dirt;
	public GameObject cloud;
	public GameObject movingPlatform;

	private float w;
	private float h;
	private float lastH;

	private int nextGenerateDistance;
	private float zoneDeleteDistance;
	public int generateDistance;
	public int zoneLength;

	private int dirtQ;
	private int pastDirtQ;
	private int grassQ;
	private int pastGrassQ;

	private int cloudCounter;

	private GameObject currentZone;
	private GameObject pastZone;

	private GameObject[] container;
	private int cubeCounter;



	private bool apex = false;
	// Use this for initialization
	void Start () {

		container = new GameObject[1000];
		cubeCounter = 0;

			playerPosition.transform.position += new Vector3 (generateDistance / 2, 0, 0);
		nextGenerateDistance = generateDistance; //Second platform will spawn at middle of first.
		w = 0.0f;
		grassQ = Random.Range (2, 4);
		pastGrassQ = 0;
		dirtQ = 5;
		cloudCounter = 0;
		zoneLength *= 2;
		//Generate starting zone
		currentZone = new GameObject ("CurrentZone");
		addDirtAndGrass ();
		zoneDeleteDistance = generateDistance/2;
		generateDistance *= 2; // Change to 60

	}
	
	// Update is called once per frame
	void Update () {


		if (Mathf.FloorToInt (playerPosition.position.x) > nextGenerateDistance) {
			zoneDeleteDistance +=zoneLength/2;
			currentZone.name = "PastZone";
			nextGenerateDistance += generateDistance; 
			currentZone = new GameObject ("CurrentZone");
			addDirtAndGrass ();



	

		}
		if (playerPosition.position.x > zoneDeleteDistance )
			Destroy (GameObject.Find("PastZone"));


 
	}

	private void addDirtAndGrass(){
		for (int i = 0; i < zoneLength; i++) {
			h = 0.0f;
			//Generate gaps

			if (Random.Range (1, 10) == 1) {
				Debug.Log ("Making Gaps");
				int gapRange = Random.Range(6,11);

				Instantiate (movingPlatform, new Vector3 (w+gapRange/2, grassQ, 0), transform.localRotation, currentZone.transform);
				w += gapRange;

			}
			if (Random.Range (1, 40) == 1)
				apex = false;

			addHill ();
			for (int j = 0; j < dirtQ; j++) {

				Instantiate (dirt, new Vector3 (w, h, 0), transform.localRotation, currentZone.transform);
				h += 0.5f;
			}
			h -= 0.25f;
			smoothGrass ();
			for (int k = 0; k < grassQ; k++) {
				Instantiate (grass, new Vector3 (w, h, 0), transform.localRotation, currentZone.transform);
				h += 0.25f;
		
			}

			if (Random.Range (1, 50) == 1)
				cloudCounter = 20;

			if (cloudCounter > 0) {
				addCloud ();
				cloudCounter--;
			}

			w += 0.5f;
		
		}

	}

	private void smoothGrass(){
		int i = Random.Range (1 , 4);

		if (i == 1 && grassQ < 4 && pastGrassQ != 1)
			grassQ++;
		else if (i == 2 && grassQ > 1 && pastGrassQ !=2)
			grassQ--;

		pastGrassQ = i;
	}

	private void addHill(){
		
		if (dirtQ < 10 && apex == false)
			dirtQ += Random.Range(0,2);
		if (dirtQ > 5 && apex == true)
			dirtQ -= Random.Range(0,2);

		if (dirtQ == 10) {
			apex = true;
		}
	}


	private void addCloud(){
		float cloudQ = Random.Range (7, 10);

		int v= Random.Range (7, 9);


		for (int l = 0; l < cloudQ; l++) {
			Instantiate (cloud, new Vector3(w, h + v, Random.Range(10,13)), transform.localRotation, currentZone.transform);
			h += 0.50f;
		}
	}



}
