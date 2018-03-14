using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour {

	public SpawnEnemyOrPowerUp s;
	public Transform start;
	public Transform end;
	public GameObject shooter;
	public float speed = 1f;
	private float startTime;
	private float journeyLength;
	private bool moveable;

	private bool changeDirection;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance (start.position, end.position);
		changeDirection = false;
		moveable = false;

		int r = Random.Range (0, 3);

		if(r == 0)
			gameObject.transform.localScale = new Vector3( 3,   1, 1);
		else if(r == 1) 
			gameObject.transform.localScale = new Vector3( 5,   1, 1);
		else if(r==2)
			gameObject.transform.localScale = new Vector3( 7,   1, 1);
		
		if (Random.Range (1, 3) == 1) {
			GameObject obj = (GameObject)Instantiate ((GameObject)s.getPowerUp(), new Vector3 (transform.position.x, transform.position.y + Random.Range(2,4), 0), transform.localRotation);
			//obj.transform.localScale = new Vector3 (obj.transform.localScale.x / transform.localScale.x, 1, 1);
		} else {
			GameObject obj = (GameObject)Instantiate ((GameObject)s.getEnemy(), new Vector3 (transform.position.x, transform.position.y + + Random.Range(2,4), 0), transform.localRotation,gameObject.transform);
			obj.transform.localScale = new Vector3 (obj.transform.localScale.x / transform.localScale.x, 1, 1);
		}



		}
			
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;


		
			



			if (changeDirection)
				transform.position = Vector3.Lerp (start.position, end.position, fracJourney);
			else
				transform.position = Vector3.Lerp (end.position, start.position, fracJourney);

			if (fracJourney > 1) { 
				changeDirection = !changeDirection;
				startTime = Time.time;
			}

	}

	public void setMoveable(){
			moveable = true;
		}
}
