using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "bullet1" && collision.gameObject.tag != "bullet2" && collision.gameObject.tag != "bullet3" && collision.gameObject.tag != "bullet4")
        {
            Destroy(gameObject);
            Debug.Log(collision.gameObject.tag);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
