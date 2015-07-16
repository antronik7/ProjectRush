using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	
	public GameObject bareDeVie;
	Vector3 pos = new Vector3 (0,0,0);

	int viePorte;

	// Use this for initialization
	void Start () {
		viePorte = 25;
	}
	
	// Update is called once per frame
	void Update () {
		if (viePorte < 1) {
			PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score") + 1);
			Application.LoadLevel("testCombat");
		}
	}

	void OnMouseDown()
	{
		viePorte--;

		pos = bareDeVie.transform.position;
		
		pos.x -= 0.4f;
		bareDeVie.transform.position = pos;
	}
}
