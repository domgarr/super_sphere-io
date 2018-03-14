using UnityEngine;
using System.Collections;

public class RandomResize : MonoBehaviour {
	public SpawnEnemyOrPowerUp s;
	public GameObject coins;
	// Use this for initialization
	void Start () {
		int length = Random.Range (4, 8);

		Transform parentTransform = gameObject.GetComponentInParent<Transform> ();

		int r = Random.Range (0, 3);

		if(r == 0)
			gameObject.transform.localScale = new Vector3( 3,   1, 1);
		else if(r == 1) 
			gameObject.transform.localScale = new Vector3( 5,   1, 1);
		else if(r==2)
			gameObject.transform.localScale = new Vector3( 7,   1, 1);

	
		//Determine spacing...
		if (length % 2 == 1) {
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x, parentTransform.position.y + 2, 0),transform.localRotation);
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x + (length * 1 / 3), parentTransform.position.y + 2, 0),transform.localRotation);
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x - (length * 1 / 3), parentTransform.position.y + 2, 0),transform.localRotation);
		} else {
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x, parentTransform.position.y + 2, 0),transform.localRotation);
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x + (length / 3), parentTransform.position.y + 2, 0),transform.localRotation);
			Instantiate (s.getBoth(), new Vector3 (parentTransform.position.x - (length / 3), parentTransform.position.y + 2, 0),transform.localRotation);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
