using UnityEngine;
using System.Collections;

public class DoorMiniGameController : MonoBehaviour {

	public GameObject bareDeTemps;


	Vector3 pos = new Vector3 (0,0,0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		pos = bareDeTemps.transform.position;
		
		pos.x -=Time.deltaTime* (1.9f + (PlayerPrefs.GetInt("Score") * 0.1f));
		bareDeTemps.transform.position = pos;
		
		if (bareDeTemps.transform.position.x <= -10.0f) {
			Application.LoadLevel("StartScene");
		}
	}
}
