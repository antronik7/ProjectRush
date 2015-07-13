using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Menu : MonoBehaviour {

	RaycastHit2D hit;
	public GameObject boutonStart;

	// Use this for initialization
	void Start () {
		hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			if (hit.collider.gameObject == boutonStart) {
				Application.LoadLevel("MainAntoine");
			}
		}
	}
}
