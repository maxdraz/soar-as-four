using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour {

	Animator anim;
	//public AnimationClip[] clips;
	GameObject playerShip;
	//public bool open = false;

	// Use this for initialization
	void Start () {
		playerShip = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown(0)) {
//			Debug.Log ("heythere");
//			anim.Play ();
//		}
	}

	public void OpenDoor () {
		anim.SetBool ("Open",true);
		Debug.Log ("Called!!");

	}

	public void CloseDoor () {
		
		anim.SetBool ("Close",true);

	}

	void OnTriggerEnter2D (Collider2D col) {
	
		if (col.gameObject == playerShip) {

			CloseDoor ();
		}
	}


}
