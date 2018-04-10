using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushSpawner : MonoBehaviour {

	public GameObject basicEnemy;
	public GameObject playerShip;
	bool canSpawn = true;

	public bool triggerSpawn;
	public int wavesToSpawn;
	public int currentWave = 0;


	public bool spawnAtStart;
	public int enemiesToSpawn;

	// Use this for initialization
	void Start () {

		playerShip = GameObject.FindGameObjectWithTag("Player");

		int roomNumber = GetComponentInParent<RoomScript> ().roomDifficulty;

		if (roomNumber >= 3) {
			wavesToSpawn++;
		}
		if (roomNumber >= 6) {
			wavesToSpawn++;
		}
		if (roomNumber >= 9) {
			wavesToSpawn++;
		}

		if (spawnAtStart){

			SpawnRandomCloud (enemiesToSpawn);
			DisableChildren ();
			canSpawn = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SpawnEvenly () {
		for (int i = 0; i < transform.childCount; i++) {
			Transform spawnPos = transform.GetChild (i);
			Instantiate (basicEnemy, spawnPos.position, transform.rotation);
		}
	}

	public void SpawnRandomCloud (int enemiesToSpawn) {
		for (int i = 0; i < enemiesToSpawn; i++) {
			int spawnZone = Random.Range (0, transform.childCount);
			Transform spawnPos = transform.GetChild (spawnZone);
			Instantiate (basicEnemy, spawnPos.position, transform.rotation);

		}
	}

	public void SpawnEnemies () {
		
		if (currentWave < wavesToSpawn) {
			currentWave++;
			SpawnEvenly();
			Invoke ("SpawnEnemies", 1f);
		}
	}

	void DisableChildren () {
		
		for (int i = 0; i < transform.childCount; i++) {

			this.gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
	}


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject == playerShip && canSpawn == true) {
			Debug.Log ("collided");

			for (int i = 0; i < transform.childCount; i++) {
			
				this.gameObject.transform.GetChild (0).gameObject.SetActive (true);
				Invoke ("DisableChildren",2f);
				canSpawn = false;
			}

			if (triggerSpawn) {
				SpawnEnemies ();
			}
		}
	}
}
