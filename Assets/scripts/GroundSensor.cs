using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    SFX SFXManager;
    Enemy enemy;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        SFXManager = GameObject.Find("SFX").GetComponent<SFX>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {    
       if (other.gameObject.layer == 3)
       {
        isGrounded = true;
       }
       else if(other.gameObject.layer == 6)
       {
        Debug.Log("enemy death");
        SFXManager.EnemyDeath();
        Enemy enemy = other.gameObject.GetComponent<enemy> ();
        enemy.Die();
       }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == 3)
       {
       isGrounded = true;     
       }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }

}