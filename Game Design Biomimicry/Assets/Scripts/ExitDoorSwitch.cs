using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorSwitch : MonoBehaviour {
	public Rigidbody2D rb;
	public BoxCollider2D downPosition;
	public ExitDoorScript exitDoor;

	// Use this for initialization
	void Start () {
		RoomScript parentScript = GetComponentInParent<RoomScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		//Debug.Log ("HIT");
		if (col == downPosition){
			rb.gravityScale = 1f;
			exitDoor.OpenDoor ();
		}
	}
}
