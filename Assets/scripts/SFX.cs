using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip enemyDeath;
    public AudioClip characterDeath;
    public AudioClip coin;
    private AudioSource source;

    void Awake()
    {
       source = GetComponent <AudioSource>(); 
    }

    public void EnemyDeath()
    {
        source.PlayOneShot(enemyDeath);
    }

    public void CharacterDeath()
    {
        source.PlayOneShot(characterDeath);
    }

    public void Coin()
    {
        source.PlayOneShot(coin);
    }

}
