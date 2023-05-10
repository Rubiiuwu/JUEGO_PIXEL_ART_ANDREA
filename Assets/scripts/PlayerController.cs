using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float PlayerSpeed =15;
    public float JumpForce =15;
    public SpriteRenderer spriteRender;
    private Rigidbody2D rBody;
    private GroundSensor groundSensor; 
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent <SpriteRenderer>();
        rBody = GetComponent <Rigidbody2D>();
        groundSensor = GameObject.Find("GroundSensor").GetComponent <GroundSensor>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(horizontal<0)
        {
            spriteRender.flipX = true;
        }
        else if(horizontal>0)
        {
            spriteRender.flipX = false;
        }

         if(Input.GetButtonDown ("Jump") && groundSensor.isGrounded)
        {
            rBody.AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate() 
    {
     rBody.velocity = new Vector2 (horizontal * PlayerSpeed, rBody.velocity.y);
    }
}