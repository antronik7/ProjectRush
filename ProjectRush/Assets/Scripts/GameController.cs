using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public bool minigameStart = false;
	public GameObject startCadena;
	public GameObject endCadena;
	public GameObject pathCadena;
	public GameObject bareDeTemps;
	GameObject monStartCadena;
	GameObject monEndCadena;
	private List <char> directionDispo = new List<char>();
	Vector3 pos = new Vector3 (0,0,0);

	RaycastHit2D hit;

	// Use this for initialization
	void Start () {
		monStartCadena = Instantiate (startCadena, new Vector3 (-4.5f, 4.5f, 0f), Quaternion.identity) as GameObject;
		monEndCadena = Instantiate (endCadena, new Vector3 (4.5f, -4.5f, 0f), Quaternion.identity) as GameObject;

		createPath();


	}
	
	// Update is called once per frame
	void Update () {
		hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (Input.GetMouseButtonDown(0))
		{
			if (hit.collider != null) {
				if (hit.collider.gameObject == monStartCadena) {
					minigameStart = true;
				}
				else
				{
					Application.LoadLevel("StartScene");
				}
			}
			else
			{
				Application.LoadLevel("StartScene");
			}
		}

		if (minigameStart) {
			if (hit.collider == null) {
				Application.LoadLevel("StartScene");
			}
			else if (hit.collider.gameObject == monEndCadena)
			{
				PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score") + 1);
				Application.LoadLevel("transicion");
			}
		}

		pos = bareDeTemps.transform.position;

		pos.x -=Time.deltaTime* (1.2f + (PlayerPrefs.GetInt("Score") * 0.1f));
		bareDeTemps.transform.position = pos;

		if (bareDeTemps.transform.position.x <= -10.0f) {
			Application.LoadLevel("StartScene");
		}
	}

	void OnMouseUp() {
		Debug.Log("Drag ended!");
	}

	void OnMouseDown() {
		Debug.Log("Drag begin!");
	}

	void OnMouseDrag() {
		
	}

	void createPath()
	{
		BoxCollider2D hitBox = monStartCadena.GetComponent<BoxCollider2D> ();
		float gap = hitBox.size.x;

		float endX = monEndCadena.transform.position.x;
		float endY = monEndCadena.transform.position.y;

		//float startX = monStartCadena.transform.position.x;
		float startY = monStartCadena.transform.position.y;

		float previousX = monStartCadena.transform.position.x;
		float previousY = monStartCadena.transform.position.y;

		bool continuer = true;

		char lastChar = '!';

		while (continuer) {
			int randomSize = Random.Range (2, 3);

			if (previousX < endX)
			{
				directionDispo.Add('r');

				if (previousY < startY && previousX != endX - gap)
				{
					directionDispo.Add('u');
				}
			}

			if (previousY > endY)
			{
				directionDispo.Add('d');
			}


			if(lastChar == 'u')
			{
				directionDispo.Remove('d');
			}
			else if(lastChar == 'd')
			{
				directionDispo.Remove('u');
			}


			int randomIndex = Random.Range (0, directionDispo.Count);

			char caseSwitch = directionDispo[randomIndex];
			Vector3 position;

			for(int i = 0; i <= randomSize - 1; i++)
			{
				switch (caseSwitch)
				{
				case 'u':
					position = new Vector3 (previousX, previousY + gap, 0f);
					break;
				case 'r':
					position = new Vector3 (previousX + gap, previousY, 0f);
					break;
				case 'd':
					position = new Vector3 (previousX, previousY - gap, 0f);
					break;
				default:
					position = new Vector3 (previousX, previousY + gap, 0f);
					break;
				}

				GameObject instance = Instantiate (pathCadena, position, Quaternion.identity) as GameObject;

				if (instance.transform.position.x > endX || instance.transform.position.y < endY)
				{
					Destroy(instance);
					i = randomSize;
				}
				else
				{
					previousX = instance.transform.position.x;
					previousY = instance.transform.position.y;
				}

				if(instance.transform.position.x == endX && instance.transform.position.y == endY)
				{
					Destroy(instance);
					continuer = false;
				}
			}

			lastChar = caseSwitch;

			directionDispo.Clear();
		}
	}
}
