using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    SFX SFXManager;
    

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        SFXManager = GameObject.Find("SFXManager").GetComponent<SFX>();
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
        Enemy enemy = other.gameObject.GetComponent<Enemy> ();
        enemy.Die();
       }
        
        if (other.gameObject.tag == "DeathZone")
       {
        Debug.Log("rip");
        SceneManager.LoadScene(2);
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