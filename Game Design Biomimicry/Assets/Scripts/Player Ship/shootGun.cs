using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootGun : MonoBehaviour {
    public float bulletSpeed = 20f;
    public bool canShoot;
    public int machineReloadTime, shotgunReloadTime;
    public int machineAmmo, shotgunAmmo;
    private int machineReload, shotgunReload;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private Transform[] shotgunSpawns;
    public string Player;
    string fire;

    public string equip = "machineGun";

    public GameObject UI;
    

    
    void Start()
    {
        machineReload = machineAmmo;
        shotgunReload = shotgunAmmo;

        

        shotgunSpawns = new Transform[5];
        for (int i = 0; i < shotgunSpawns.Length; i++)
        {
            shotgunSpawns[i] = this.gameObject.transform.GetChild(i);
            //Debug.Log(shotgunSpawns[i]);
        }

        canShoot = true;
        fire = string.Format("Fire{0}", Player);

        
    }

    private void Update()
    {
        
        if (Input.GetAxis(fire) == -1 && canShoot)
        {
            if (equip == "machineGun")
            {
                if (machineReload > 0)
                {
                    Fire();
                }
                else
                {
                    Debug.Log("shotgunMag");
                    Invoke("reloadMagazine", machineReloadTime);
                }
            }
            else if (equip == "shotGun")
            {
                if (shotgunReload > 0)
                {
                    Debug.Log(shotgunReload);
                    shotgunFire();

                }
                else
                {
                    
                    Invoke("reloadMagazine", shotgunReloadTime);
                }

            }
        }

    }

    // Update is called once per frame
    private void FixedUpdate () {
        //Debug.LogWarning(Input.GetAxis("Fire1"));
        
    }

    void Fire()
    {
        if (canShoot == true)
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
            machineReload--;
            UI.GetComponent<progressionCircle>().shotFired(1, machineAmmo);
            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
            canShoot = false;
            StartCoroutine(ShootDelay(0.2f));
        }

    }

    void shotgunFire()
    {
        if (canShoot == true)
        {
            UI.GetComponent<progressionCircle>().shotFired(shotgunSpawns.Length, shotgunAmmo);
            shotgunReload-= shotgunSpawns.Length;
            for (int i = 0; i < shotgunSpawns.Length; i++)
            {

                var bullet = Instantiate(
                    bulletPrefab,
                    shotgunSpawns[i].position,
                    shotgunSpawns[i].rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
                
                
                /* 

        

         void Shoot () {
             canShoot = false;
             
             magazineCheck ();
             }
     void Shoot () {
             canShoot = false;
             magazineSize--;
             magazineCheck ();
             audio.volume = .2f;
             audio.clip = clips [0];
             audio.Play ();


         void magazineCheck () {
             if (magazineSize == 0) {
                 Debug.Log ("Reloading");

                 Invoke ("reloadMagazine", 1.8f);

             } else {
                 Invoke ("ReadyToShoot", fireRate);
             }
         }

         void reloadMagazine () {
             magazineSize = whatever;
             canShoot = true;

         }
     void ReadyToShoot () {

                 canShoot = true;
             }

                 /*
                 GameObject[] bullet;
                 bullet = new GameObject[shotgunSpawns.Length];
                 //shotgunSpawns[i].transform.position = new Vector3((transform.position.x - Random.Range(-0.5f, 0.5f)), transform.position.y);
                 bullet[i] = Instantiate(bulletPrefab, shotgunSpawns[i].position, shotgunSpawns[i].rotation);
                 bullet[i].GetComponent<Rigidbody2D>().velocity = bullet[i].transform.right * bulletSpeed;*/

                Destroy(bullet, 1.0f);

            }
            
            


            // Add velocity to the bullet


            // Destroy the bullet after 2 seconds

            canShoot = false;
            StartCoroutine(ShootDelay(0.4f));
        }
    }

    

    void reloadMagazine()
    {
        if (equip == "machineGun")
        {
            machineReload = machineAmmo;
            UI.GetComponent<progressionCircle>().reload();
        }
        else if (equip == "shotGun")
        {
            shotgunReload = shotgunAmmo;
            Debug.Log("Reload");
            UI.GetComponent<progressionCircle>().reload();
        }
    }

    public void newWeapon()
    {
        reloadMagazine();
    }

    IEnumerator ShootDelay(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}
