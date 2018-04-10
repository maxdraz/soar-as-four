using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMove : MonoBehaviour
{
    public float shipSpeed = 10f;
    private Rigidbody2D rb;
    public float maxVelocity = 12;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float shipSPeed = rb.velocity.magnitude;
        //Debug.Log(shipSPeed);

    }
    public string Player;
    float xAxis;
    float yAxis;
    private void FixedUpdate()
    {
        if (Player == "1")
        {
            xAxis = Input.GetAxis("Horizontal");
            yAxis = Input.GetAxis("Vertical");
        }
        else if (Player == "2")
        {
            xAxis = Input.GetAxis("Horizontal2");
            yAxis = Input.GetAxis("Vertical2");
        }
        else if (Player == "3")
        {
            xAxis = Input.GetAxis("Horizontal3");
            yAxis = Input.GetAxis("Vertical3");
        }
        else
        {
            xAxis = Input.GetAxis("Horizontal4");
            yAxis = Input.GetAxis("Vertical4");
        }
        

        clampVolicity();
        //if (Mathf.Abs(xAxis) >= Mathf.Abs(yAxis))
        //{
            thrustSideways(xAxis);
       // }
       // else if (Mathf.Abs(yAxis) >= Mathf.Abs(xAxis))
      //  {
            thrustForward(yAxis);
      //  }
        

    }

    private void clampVolicity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void thrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        
        rb.AddForce(force * shipSpeed); // GREAT FOR CHARGE! ForceMode2D.Impulse); // ** FIX MULTIPLIER
    }

    private void thrustSideways(float amount)
    {
        Vector2 force = transform.right * amount;
        
        rb.AddForce(force * shipSpeed);
    }

    /*
      bool mvHoz;
 bool mvVer;
 
 float xPos = 0, yPos = 0;
 if (Input.GetAxis(“Vertical”) != 0 && Input.GetAxis(“Horizontal”) != 0){
     if (mvHoz){
         yPos = Input.GetAxis(“Vertical”);
     }else if  (mvVer){
         xPos = Input.GetAxis(“Horizontal”);
     }
 }else {
     mvHoz = Input.GetAxis(“Horizontal”) != 0;
     xPos = Input.GetAxis(“Horizontal”);
     mvVer = Input.GetAxis(“Vertical”) != 0;
     yPos = Input.GetAxis(“Vertical”);
 }
 
 transform.position += new Vector3(xPos, yPos, 0).normalized * spd * Time.deltaTime;
     */
}
