using UnityEngine;
using System.Collections;

public class transicion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Transicion());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Transicion() {
		int radomNum = Random.Range (1, 4);
		yield return new WaitForSeconds(1);
		Application.LoadLevel (radomNum);
	}
}
