using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceEnemyMove : MonoBehaviour {

    // Use this for initialization
    Vector3 myDirectionVector;

    void Start () {
        int myDirection = Random.Range(0, 4);
        myDirectionVector = new Vector3();
        switch (myDirection)
        {
            case 0:
                myDirectionVector = Vector3.up;
                break;//now break the switch
            case 1:
                myDirectionVector = Vector3.down;
                break;
            case 2:
                myDirectionVector = Vector3.left;
                break;
            default:
                myDirectionVector = Vector3.right;
                break;

                

        }

        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    int x = 5;
    // Update is called once per frame
    void Update () {

        if (x < 10)
        {
            GetComponent<Rigidbody2D>().AddForce(myDirectionVector * 0.5f, ForceMode2D.Impulse);
            x++;
        }
        
    }
}
