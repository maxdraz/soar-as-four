using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyDeath : MonoBehaviour {

    public int enemyHealth;
    public int bulletDamage;
    public int crashDamage;
    public GameObject playerShip;

    
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet1" || collision.gameObject.tag == "bullet2" || collision.gameObject.tag == "bullet3" || collision.gameObject.tag == "bullet4")
        {
            enemyHealth -= bulletDamage;
            playerShip.GetComponent<shipData>().takeDamage(0, true);
        }

        if (collision.transform.tag == "Player")
        {
            enemyHealth -= crashDamage;

            playerShip.GetComponent<shipData>().takeDamage(crashDamage, false);
        }
    }


    // Update is called once per frame
    void Update () {
		if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
}
