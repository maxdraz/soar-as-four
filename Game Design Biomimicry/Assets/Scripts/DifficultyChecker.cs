using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChecker : MonoBehaviour {


	public int numberToReach;


	// Use this for initialization
	void Start () {
		int currentNumber = GetComponentInParent<RoomScript> ().roomDifficulty;

		if (currentNumber >= numberToReach) {

			this.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		}
	}
}
