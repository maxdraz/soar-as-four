using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLerp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public Transform from;
    public Transform to;
    public float speed = 0.1F;
    
    
    void Update()
    {

       
        transform.rotation = Quaternion.RotateTowards(from.rotation, to.rotation, speed);


    }
}
