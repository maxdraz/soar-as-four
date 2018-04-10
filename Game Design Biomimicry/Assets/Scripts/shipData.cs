using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shipData : MonoBehaviour {
    public int health = 300;
    public Text HPBar;

	public GameObject player1gun, player2gun, player3gun, player4gun;
	private string[] weaponStorage;
	private int[] weaponAvail;

    private int enemiesKilled;

	public int currentExperience = 0;
	int level1 = 10;
	int level2 = 30;
	int level3 = 100;

	//VALUES TO SEND OUT
	public int shipSpeed = 1;
	public int turretSpeed = 1;
	public int knockback = 1;

	public int speedInvestment = 0;
	public bool level1Speed = false;
	public bool level2Speed = false;
	public bool level3Speed = false;

	public int turretInvestment = 0;
	public bool level1Turrets = false;
	public bool level2Turrets = false;
	public bool level3Turrets = false;

	public int knockbackInvestment = 0;
	public bool level1Knockback = false;
	public bool level2Knockback = false;
	public bool level3Knockback = false;

   



    // Use this for initialization
    void Start () {
        weaponStorage = new string[4];
        weaponStorage[0] = "machineGun";
        weaponStorage[1] = "machineGun";
        weaponStorage[2] = "machineGun";
        weaponStorage[3] = "machineGun";

        weaponAvail = new int[4];
        weaponAvail[0] = 1;
        weaponAvail[1] = 2;
        weaponAvail[2] = 3;
        weaponAvail[3] = 4;

       //HPBar.text = "Health: " + health;
       // enemyKillCount.text = "Enemies Killed: " + enemiesKilled;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckSpeedXP ();
		CheckTurretXP ();
		CheckKnockbackXP ();
	}

    public void takeDamage(int value, bool dead)
    {
        health -= value;
       HPBar.text = "Health: " + health;
        if (health <= 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void swapWeapon(int playerNum)
    {
        for (int i = 0; i < weaponAvail.Length; i++)
        {
            if (weaponAvail[i] == playerNum && weaponAvail.Length > 4)
            {
                int swap = i;
                weaponAvail[i] = 0;
                while (weaponAvail[swap] != 0)
                {
                    swap += 1;
                }
                weaponAvail[swap] = playerNum;
                updateGuns(playerNum, weaponStorage[swap]);
            }
        }
    }

    public void newWeapon(string playerTag, string weapon)
    {

        weaponStorage = new string[weaponStorage.Length + 1];
        weaponAvail = new int[weaponStorage.Length];
        weaponStorage[weaponStorage.Length - 1] = weapon;

        
        if (playerTag == "bullet1")
        {
            for (int i = 0; i < weaponAvail.Length; i++)
            {
                if (weaponAvail[i] == 1)
                {
                    weaponAvail[i] = 0;
                }
            }
            weaponAvail[weaponStorage.Length - 1] = 1;
            updateGuns(1, weaponStorage[weaponStorage.Length - 1]);
        }
        else if (playerTag == "bullet2")
        {
            for (int i = 0; i < weaponAvail.Length; i++)
            {
                if (weaponAvail[i] == 2)
                {
                    weaponAvail[i] = 0;
                }
            }
            weaponAvail[weaponStorage.Length - 1] = 2;
            updateGuns(2, weaponStorage[weaponStorage.Length - 1]);
        }
        else if (playerTag == "bullet3")
        {
            for (int i = 0; i < weaponAvail.Length; i++)
            {
                if (weaponAvail[i] == 3)
                {
                    weaponAvail[i] = 0;
                }
            }
            weaponAvail[weaponStorage.Length - 1] = 3;
            updateGuns(3, weaponStorage[weaponStorage.Length - 1]);
        }
        else
        {
            for (int i = 0; i < weaponAvail.Length; i++)
            {
                if (weaponAvail[i] == 4)
                {
                    weaponAvail[i] = 0;
                }
            }
            weaponAvail[weaponStorage.Length - 1] = 4;
            updateGuns(4, weaponStorage[weaponStorage.Length - 1]);
        }
    }

    private void updateGuns(int player, string gun)
    {
        if (player == 1)
        {
            player1gun.GetComponent<shootGun>().equip = gun;
            player1gun.GetComponent<shootGun>().newWeapon();
        }
        if (player == 2)
        {
            player2gun.GetComponent<shootGun>().equip = gun;
           // player2gun.GetComponent<shootGun>().newWeapon();
        }
        if (player == 3)
        {
            player3gun.GetComponent<shootGun>().equip = gun;
          //  player3gun.GetComponent<shootGun>().newWeapon();
        }
        else
        {
            player4gun.GetComponent<shootGun>().equip = gun;
          //  player4gun.GetComponent<shootGun>().newWeapon();
        }

    }

	void CheckSpeedXP () {
		if (speedInvestment >= level1 && !level1Speed) {
			level1Speed = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			shipSpeed++;
			Debug.Log ("SPEED");

		}
		if (speedInvestment >= level2 && !level2Speed) {
			level2Speed = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			shipSpeed++;

		}
		if (speedInvestment >= level3 && !level3Speed) {
			level3Speed = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			shipSpeed++;

		}
	}

	void CheckTurretXP () {
		if (turretInvestment >= level1 && !level1Turrets) {
			level1Turrets = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			turretSpeed++;
			Debug.Log ("Turrets");

		}
		if (turretInvestment >= level2 && !level2Turrets) {
			level2Turrets = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			turretSpeed++;

		}
		if (turretInvestment >= level3 && !level3Turrets) {
			level3Turrets = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			turretSpeed++;
		}
	
	}

	void CheckKnockbackXP () {
		if (knockbackInvestment >= level1 && !level1Knockback) {
			level1Knockback = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			knockback++;

			}
		if (knockbackInvestment >= level2 && !level2Knockback) {
			level2Knockback = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			knockback++;

			}
		if (knockbackInvestment >= level3 && !level3Knockback) {
			level3Knockback = true;
			//CHANGE HERE TO BALANCE THE LEVELLING
			knockback++;
		}
	}

	void IncreaseSpeedXP () {
		currentExperience--;
		speedInvestment++;
	}

	void IncreaseTurretXP () {
		currentExperience--;
		turretInvestment++;
	}

	void IncreaseKnockbackXP () {
		currentExperience--;
		knockbackInvestment++;
	}


	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag == "ShipSpeed") {
			
			InvokeRepeating ("IncreaseSpeedXP", .01f, .1f);
		}

		if (col.gameObject.tag == "TurretSpeed") {
			
			InvokeRepeating ("IncreaseTurretXP", .01f, .1f);
		}

		if (col.gameObject.tag == "Knockback") {
			
			InvokeRepeating ("IncreaseKnockbackXP", .01f, .1f);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "ShipSpeed" || col.gameObject.tag == "TurretSpeed" || col.gameObject.tag == "Knockback") {
		CancelInvoke ("IncreaseSpeedXP");
		CancelInvoke ("IncreaseTurretXP");
		CancelInvoke ("IncreaseKnockbackXP");
		}
	}
}
