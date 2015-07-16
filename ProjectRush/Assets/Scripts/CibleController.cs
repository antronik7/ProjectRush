using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CibleController : MonoBehaviour {

	public GameObject controller;
	CombatController combatController;
	float valeur = 0;

	void Awake ()
	{

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		valeur = -Time.deltaTime * (1.4f + ((PlayerPrefs.GetInt("Score")/2) * 0.1f));
		this.gameObject.transform.localScale += new Vector3(valeur, valeur, 0);

		if (this.gameObject.transform.localScale.x <= 1.5) {
			Application.LoadLevel("StartScene");
		}
	}

	void OnMouseDown()
	{
		combatController = controller.GetComponent<CombatController>();

		if(this.gameObject.transform.localScale.x < 2.1 && this.gameObject.transform.localScale.x > 1.5)
		{
			combatController.destroyCible();
		}
		else
		{
			Application.LoadLevel("StartScene");
		}
	}
}
