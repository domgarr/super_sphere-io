using UnityEngine;
using System.Collections;

public class GenerateHills : MonoBehaviour {
	public GameObject grass;

	private float w;
	private float h;

	public int min;
	public int max;
	public int hillQuantity;

	private bool apexCheck;
	int hillCount;
	// Use this for initialization
	void Start () {
		w = 0.0f;
		hillCount = 0;

	}

	// Update is called once per frame
	void Update () {
		hillCount++;

		if(hillCount < hillQuantity){
		apexCheck = false;
		int height = Random.Range (min, max);
		int a = 1;
		for(int i = 0; a > 0; i++){
			h = 0f;

			if ((height/2) > a && !apexCheck)
				a += Random.Range(0,2);
			else {
				a -=Random.Range(0,2);
				apexCheck = true;
			}

			for (int j = 0; j < a; j++) {

				Instantiate (grass, new Vector3 (w, h, transform.position.z), transform.localRotation, gameObject.transform);
				h += 0.5f;
			}
			w += 0.5f;
		}
	}
			}
}
