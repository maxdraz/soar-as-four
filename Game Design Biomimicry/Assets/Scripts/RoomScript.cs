using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

	public int roomDifficulty;



	// Use this for initialization
	void Start () {
		GameObject roomGenerator = GameObject.FindGameObjectWithTag ("RoomGenerator");
		roomDifficulty = roomGenerator.GetComponent<Generator> ().roomNumber;
		roomGenerator.GetComponent<Generator>(). ChangeRoomNumber ();
		Debug.Log (roomDifficulty);
	
	
		//BroadcastMessage ("ActivationCheck");
	}
	

}
