using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatController : MonoBehaviour {

	public GameObject snake;
	public GameObject cercle;
	public GameObject cible;
	public int compteurCibles = 0;
	public int penis = 69;

	SpriteRenderer monSprite;
	float sizeSnakeX;
	float sizeSnakeY;
	float positionRanX;
	float positionRanY;
	Vector3 position;

	GameObject instanceCercle;
	GameObject instanceCible;


	// Use this for initialization
	void Start () {
		monSprite = snake.GetComponent<SpriteRenderer> ();
		sizeSnakeX = monSprite.bounds.extents.x;
		sizeSnakeY = monSprite.bounds.extents.y;

		createCible ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createCible()
	{

		positionRanX = Random.Range (-sizeSnakeX, sizeSnakeX);
		positionRanY = Random.Range (-sizeSnakeY, sizeSnakeY);

		position = new Vector3 (positionRanX, positionRanY, 0f);

		instanceCercle = Instantiate (cercle, position, Quaternion.identity) as GameObject;
		CibleController myCible = instanceCercle.GetComponent<CibleController>();
		myCible.controller = gameObject;
		instanceCible = Instantiate (cible, position, Quaternion.identity) as GameObject;


	}

	public void destroyCible()
	{
		Debug.Log ("Bonjour");
		Destroy (instanceCercle);
		Destroy (instanceCible);

		compteurCibles++;

		if (compteurCibles >= 10) {
			Application.LoadLevel ("MainAntoine");
		} 
		else {
			createCible();
		}
		Debug.Log ("Au revoir");
	}
}
