using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public Transform objectToSpawn;

    public int spawnNumber;

    public bool spawnNow;
    public Transform parentT;

    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (spawnNow)
        {
            SpawnNow();
        }
    }

    public void SpawnNow()
    {
        spawnNow = false;
        for (int i = 0; i < spawnNumber; i++)
            SpawnNew();
    }

    void SpawnNew()
    {
        float _xWidth = (collider.size.x * transform.lossyScale.x);
        float _yWidth = (collider.size.y * transform.lossyScale.y);
        //float _zWidth = (collider.size.z * transform.lossyScale.z);

        float x = transform.position.x + collider.offset.x - _xWidth / 2.0f;
        float y = transform.position.y + collider.offset.y - _yWidth / 2.0f;
        //float z = transform.position.z + collider.offset.z - _zWidth / 2.0f;

        Vector3 _pos = new Vector3(Random.Range(x, x + _xWidth), Random.Range(y, y + _yWidth));// Random.Range(z, z + _zWidth));

        Transform _new = (Transform)Instantiate(objectToSpawn, _pos, objectToSpawn.rotation);

        if (parentT != null)
            _new.parent = parentT;
    }
}
