using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour {

	public float defaultView = 14f;
	public float currentView;
	public float combatView = 18f;
	public bool inCombat;
	public Camera camera;
	public float zoomSpeed = .1f;

	// Use this for initialization
	void Start () {
		inCombat = false;
	}
	
	// Update is called once per frame
	void Update () {

		currentView = camera.orthographicSize;

		if (inCombat == true) {
			camera.orthographicSize = (float)Mathf.Lerp(camera.orthographicSize, combatView, zoomSpeed);
		}

		if (inCombat == false) {
			camera.orthographicSize = (float)Mathf.Lerp(camera.orthographicSize, defaultView, zoomSpeed);
		}
	}

	void OnTriggerStay2D (Collider2D col) {

		if (col.gameObject.tag == "enemy") {
			inCombat = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {

		if (col.gameObject.tag == "enemy") {
			inCombat = false;
		}
	}
}
