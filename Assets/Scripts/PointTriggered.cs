using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTriggered : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("trigged " + other.gameObject.tag + " " + other.gameObject.name);

		if (other.gameObject.tag == "player") {
			GameManager.instance.addScore ();
		}
	}
}
