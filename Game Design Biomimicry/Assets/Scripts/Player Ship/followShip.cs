using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followShip : MonoBehaviour {


    

    // Use this for initialization
    void Start () {
		
	}

    public GameObject target;

    void Update()
    {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        transform.position = pos;
	
    }
}
