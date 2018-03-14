using UnityEngine;
using System.Collections;

public class GenerateBackgroundGrass : MonoBehaviour {
	public GameObject lightGrass;
	public GameObject darkGrass;

	private float h;
	private float w;
	private float z;
	// Use this for initialization
	void Start () {
		h = 0;
		w = 0;
		z = transform.position.z;
	

		for (int i = 0; i < 500; i++) {
			z = transform.position.z;

			for(int j = 0 ; j < 50 ; j++){
				h = 0;
				Instantiate(lightGrass, new Vector3(w,h,z),transform.localRotation, gameObject.transform);
				h += 0.1f;
				int r = Random.Range (0, 2);
				for(int k = 0 ; k < r ; k++){
					if (Random.Range (0, 4) == 1) {
						Instantiate (darkGrass, new Vector3 (w, h, z), transform.localRotation, gameObject.transform);
						h += 0.10f;
					}
				}
				z += 0.5f;
			}
			w += 0.5f;
		}
	}

	
	// Update is called once per frame
	void Update () {


}
}
