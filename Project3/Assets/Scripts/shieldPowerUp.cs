﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPowerUp : MonoBehaviour
{
    //effect of powerup pickup
    public float time;
    //variable for the effect on pickup
    public GameObject effect;
    public GameObject shieldFX;
    //Executes on powerup collision
    public void OnTriggerEnter(Collider other)
    {
        //When collider is triggered, checks if powerup collided with the player
        if (other.CompareTag("Player"))
        {
            //Time management for effect time and powerup period using the player object
            StartCoroutine(pickup(other));
        }
    }
    //Player powerup pickup effects
    IEnumerator pickup(Collider player)
    {
        //Effect on pickup of powerup at the player's current position and rotation
        GameObject myEffect = Instantiate(effect, player.transform.position, player.transform.rotation);
        myEffect.transform.parent = player.transform;
        GameObject myShield = Instantiate(shieldFX, player.transform.position, player.transform.rotation);
        myShield.transform.parent = player.transform;
        //removes power up visuals after pickup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //waits for the given power up duration
        yield return new WaitForSeconds(time);
        //destroys power up object when effects wear off
        GameObject powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        Destroy(gameObject);
    }
}
