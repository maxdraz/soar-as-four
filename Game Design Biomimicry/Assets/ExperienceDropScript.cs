using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDropScript : MonoBehaviour {

	public GameObject Player;
	public float lerpSpeed = .2f;
	public bool collided;


	// Use this for initialization
	void Start () {
		collided = false;
		Invoke ("SelfDestruct",5f);
	}
	
	// Update is called once per frame
	void Update () {

		if (collided) {
			transform.position = Vector3.Lerp(transform.position, Player.transform.position, lerpSpeed);
		}
	}

	void SelfDestruct() {

		Destroy (this.gameObject);
	}


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject == Player) {
			CancelInvoke ();
			collided = true;
			Invoke ("SelfDestruct", .2f);
			col.GetComponent<shipData> ().currentExperience++;
		}
	}
}
