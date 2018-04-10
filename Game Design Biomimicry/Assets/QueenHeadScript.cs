using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenHeadScript : MonoBehaviour {

	public GameObject BasicEnemy;
	public float basicEnemyShootForce;
	public GameObject BouncyEnemy;
	public float bouncyEnemyShootForce;
	public GameObject BouncyBullet;
	public float bouncyBulletShootForce;
	public Transform shootingPos;

	public int firstPhaseAttackRate;
	public int firstRandomNumber;
	public int secondPhaseAttackRate;
	public int secondRandomNumber;

	public int timesWithoutFiring;
	int timesFired;
	int numberNeededToScream;
	public bool vulnerable = false;
	bool isScreaming = false;
	bool isAttacking = false;


	public int healthTotal;
	public int currentHealth;
	public int secondPhaseHealth;
	public bool isSecondPhase;

	// Use this for initialization
	void Start () {
		
		CalcSecondPhase (healthTotal);
		currentHealth = healthTotal;
		CalcFirstPhaseAttackRate ();
		CalcSecondPhaseAttackRate ();




	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= secondPhaseHealth) {
			isSecondPhase = true;

		}
	}

	void CalcFirstPhaseAttackRate () {
		firstPhaseAttackRate = Random.Range (0, firstRandomNumber) + 2;
	
	}

	void CalcSecondPhaseAttackRate () {
	
		secondPhaseAttackRate = Random.Range (0, secondRandomNumber) + 2;
	}

	public void LeftToRight() {
		timesWithoutFiring++;
		if (isSecondPhase) {
			if (timesWithoutFiring >= secondPhaseAttackRate) {
				isAttacking = true;
				timesFired++;
			}
			if (timesWithoutFiring >= firstPhaseAttackRate) {
				isAttacking = true;
				timesFired++;
			} else {
				Debug.Log ("Left to right");

			}
		}
	}

	public void RightToLeft() {
		timesWithoutFiring++;
		if (isSecondPhase) {
			if (timesWithoutFiring >= secondPhaseAttackRate) {
				isAttacking = true;
				timesFired++;
			}
			if (timesWithoutFiring >= firstPhaseAttackRate) {
				isAttacking = true;
				timesFired++;
			} else {
				Debug.Log ("Right to left");

			}
		}
	}

	public void CancelEffect () {
		

		if (isSecondPhase) {

			CalcSecondPhaseAttackRate ();
		} else {
		
			CalcFirstPhaseAttackRate ();
		}

		if (isAttacking) {
			isAttacking = false;
			timesWithoutFiring = 0;
		}

		Debug.Log ("Finished");
	}

	int CalcSecondPhase (int healthTotal) {
		secondPhaseHealth = healthTotal / 3;
		return secondPhaseHealth;
		Debug.Log (secondPhaseHealth);
	}

	public void ShootBasicEnemy () {
		if (isAttacking) {
			GameObject enemyInstance = Instantiate (BasicEnemy, shootingPos.position, shootingPos.rotation);
			enemyInstance.GetComponent<Rigidbody2D> ().AddForce (transform.forward* basicEnemyShootForce);
		}
	}

	public void ShootBouncyEnemy () {
		if (isAttacking && isSecondPhase) {
			GameObject enemyInstance = Instantiate (BouncyEnemy, shootingPos.position, shootingPos.rotation);
			enemyInstance.GetComponent<Rigidbody2D> ().AddForce (transform.forward* bouncyEnemyShootForce);

		}
	}

	public void ShootProjectile () {
		if (isAttacking) {
			Debug.Log ("PEWPEW");
			GameObject bulletInstance = Instantiate (BouncyBullet, shootingPos.position, shootingPos.rotation);
			bulletInstance.GetComponent<Rigidbody2D> ().AddForce (transform.forward* bouncyBulletShootForce);
		}
	}

	public void CheckToScream () {
		if (timesFired >= numberNeededToScream) {
			isScreaming = true;

		}
	}

	void ToggleScream () {
		if (isScreaming = true) {
			isScreaming = false;
		} else {
			isScreaming = true;
		}
	}
}
