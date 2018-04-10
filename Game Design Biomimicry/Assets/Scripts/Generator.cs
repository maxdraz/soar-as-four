using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject[] rooms;
	public Transform nextRoomTransform;
	public int numberOfRoomsToSpawn = 10;
	public int lastRoomSpawned = 15;
	public int roomToSpawn;
	public int roomNumber = 1;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < numberOfRoomsToSpawn; i++) {
			SpawnRoom ();

		}
	}

	public void ChangeRoomNumber () {
	
		roomNumber++;
	}


	void SpawnRoom() {
		
//		roomToSpawn = Random.Range (0, rooms.Length);
//
//		if (roomToSpawn == lastRoomSpawned) {
//			RandomiseRoom ();
//		}
		RandomiseRoom();

		GameObject roomBeingSpawned = rooms[roomToSpawn];
		GameObject spawnedRoom = Instantiate (roomBeingSpawned, nextRoomTransform.position, nextRoomTransform.rotation);
		//spawnedRoom.gameObject.GetComponent<RoomScript> ().roomDifficulty = roomNumber;
		nextRoomTransform = spawnedRoom.GetComponentsInChildren<Transform>()[1];
		lastRoomSpawned = roomToSpawn;


	}
	void RandomiseRoom (){
		roomToSpawn = Random.Range (0, rooms.Length);

		if (roomToSpawn == lastRoomSpawned) {
			RandomiseRoom ();
		}
	}
}
