using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorScript : MonoBehaviour {

	GameObject playerShip;
	EntranceDoorScript parentScript;

	// Use this for initialization
	void Start () {
		playerShip = GameObject.FindGameObjectWithTag ("Player");
		parentScript = GetComponentInParent<EntranceDoorScript> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject == playerShip) {
			parentScript.CloseDoor ();
		}
	}
}
