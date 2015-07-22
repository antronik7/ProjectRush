using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Menu : MonoBehaviour {

	RaycastHit2D hit;
	public Text highScoreText;

	void Awake()
	{
		if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore",PlayerPrefs.GetInt("Score"));
		}

		highScoreText.text = "High Score :\n" + PlayerPrefs.GetInt("HiScore");

		PlayerPrefs.SetInt("Score",0);
	}
	
	// Use this for initialization
	void Start () {
		;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Application.LoadLevel("transicion");
	}
}
