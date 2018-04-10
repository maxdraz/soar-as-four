using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoorScript : MonoBehaviour {

	Animator anim;
	GameObject playerShip;

	// Use this for initialization
	void Start () {
		
		playerShip = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void CloseDoor () {
		anim.SetBool ("Close",true);


	}
		

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject == playerShip) {

			anim.SetBool("Open",true);
		}
	}
}
