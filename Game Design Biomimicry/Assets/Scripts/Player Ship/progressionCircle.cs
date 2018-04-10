using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressionCircle : MonoBehaviour {

    Image playerAmmo;
    public float ammo = 1;
    // Use this for initialization
    void Start () {
    playerAmmo = gameObject.GetComponent<Image>();
      //  playerAmmo.fillAmount = ammo;
    }
	
	// Update is called once per frame
	void Update () {

      //  playerAmmo.fillAmount -= 0.01f;
    }

    public void shotFired(int amount, int total)
    {
        
        playerAmmo.fillAmount -= (float)amount / total;
    }
    public void reload()
    {
        Debug.Log("Reloading");
        if (playerAmmo.fillAmount == 0)
        playerAmmo.fillAmount = 1;
    }
}
