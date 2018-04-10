using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class gunMotion : MonoBehaviour {

    
    public string Player;

    public Transform ship;
    public float rotationSpeed = 2;

    float xAxis;
    float yAxis;

    
    

    // Update is called once per frame
    private void FixedUpdate () {
        

        if (Player == "1")
        {
            xAxis = Input.GetAxis("rotationX");
            yAxis = Input.GetAxis("rotationY");
        }
        else if (Player == "2")
        {
            xAxis = Input.GetAxis("rotationX2");
            yAxis = Input.GetAxis("rotationY2");
        }
        else if (Player == "3")
        {
            xAxis = Input.GetAxis("rotationX3");
            yAxis = Input.GetAxis("rotationY3");
        }
        else
        {
            xAxis = Input.GetAxis("rotationX4");
            yAxis = Input.GetAxis("rotationY4");
        }

        

        if (xAxis != 0.0f || yAxis != 0.0f)
        {
            float angle = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
       
       

        
    }

    private void rotate(float amount)
    {
        // Debug.LogWarning(amount);
        //transform.RotateAround(ship.position, Vector3.forward, amount);

        

    }





}
