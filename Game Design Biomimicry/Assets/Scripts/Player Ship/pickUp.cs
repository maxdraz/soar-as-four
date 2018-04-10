using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

    private GameObject ship;
    private string pickUpWeapon;

	// Use this for initialization
	void Start () {
        pickUpWeapon = "shotGun";


        ship = GameObject.FindWithTag("Player");
	}
    int shield = 300;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet1" || collision.gameObject.tag == "bullet2" || collision.gameObject.tag == "bullet3" || collision.gameObject.tag == "bullet4")
        {
            shield -= 10;

            if (shield <= 0)
            {
                if (collision.gameObject.tag == "bullet1")
                {
                    ship.GetComponent<shipData>().newWeapon(collision.gameObject.tag, pickUpWeapon);
                }
                else if (collision.gameObject.tag == "bullet2")
                {
                    ship.GetComponent<shipData>().newWeapon(collision.gameObject.tag, pickUpWeapon);
                }
                else if (collision.gameObject.tag == "bullet3")
                {
                    ship.GetComponent<shipData>().newWeapon(collision.gameObject.tag, pickUpWeapon);
                }
                else
                {
                    ship.GetComponent<shipData>().newWeapon(collision.gameObject.tag, pickUpWeapon);
                }

                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
