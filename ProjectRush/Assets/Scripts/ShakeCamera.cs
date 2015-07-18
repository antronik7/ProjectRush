using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

	public float secondesShake;
	public float rayonShake;
	public float vitesseShake;

	Vector3 positionRandom;
	Transform startPosition;
	float startTime;
	float distanceShake;
	float distCovered;
	float fracDistance;
	float timer;
	Vector3 positionInitial;
	bool continuerShake = false;
	bool besoinRandom = true;

	// Use this for initialization
	void Start () {
		startShake ();
	}
	
	// Update is called once per frame
	void Update () {

		if (continuerShake) {

			if (timer > 0)
			{
				if(besoinRandom)
				{
					positionRandom = new Vector3(Random.Range(positionInitial.x - rayonShake, positionInitial.x + rayonShake), Random.Range(positionInitial.y - rayonShake, positionInitial.y + rayonShake), positionInitial.z);


					startPosition = transform;
					startTime = Time.time;
					distanceShake = Vector3.Distance(transform.position, positionRandom);
					besoinRandom = false;
				}

				distCovered = (Time.time - startTime) * vitesseShake;
				fracDistance = distCovered / distanceShake;

				transform.position = Vector3.MoveTowards(startPosition.position, positionRandom, fracDistance);

				timer -= Time.deltaTime;

				if (transform.position == positionRandom)
				{
					besoinRandom = true;
				}
			}
			else
			{
				Debug.Log(transform.position);

				if(transform.position == positionInitial)
				{
					continuerShake = false;
				}
				else
				{
					distCovered = (Time.time - startTime) * vitesseShake;
					fracDistance = distCovered / distanceShake;
					
					transform.position = Vector3.MoveTowards(positionRandom, positionInitial, fracDistance);
				}
			}
		}
	}

	void startShake(){

		positionInitial = transform.position;
		timer = secondesShake;


		continuerShake = true;
	}
}
