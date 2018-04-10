using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int numberToSpawn = Random.Range (0, transform.childCount);
		//GameObject switchToSpawn = transform.GetChild (numberToSpawn);
		this.gameObject.transform.GetChild (numberToSpawn).gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
