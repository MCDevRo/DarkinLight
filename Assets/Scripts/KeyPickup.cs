using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public ParticleSystem glowVfx;

    //public GameObject pickupEffect;
    private void Start()
    {
        glowVfx.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("White"))
        {
            FindObjectOfType<AudioManager>().Play("keyFound");
            PickUp(collision);
        }
        else if (collision.gameObject.CompareTag("Black"))
        {
            FindObjectOfType<AudioManager>().Play("keyFound");
            PickUpDark(collision);
        }

    }

    void PickUp(Collider2D player)
    {
        //Spawn effect here for pickup!
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply the key to player!
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        inventory.lightKey++;
        Debug.Log("the value of" + inventory.lightKey + "is : ");
        //Remove keyObject from Scene.
        Destroy(gameObject);
        //Debug.Log("Key Picked up!");
    }
    void PickUpDark(Collider2D player)
    {
        //Spawn effect here for pickup!
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply the key to player!
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        inventory.darkKey++;
        Debug.Log("the value of" + inventory.lightKey + "is : ");
        //Remove keyObject from Scene.
        Destroy(gameObject);
        //Debug.Log("Key Picked up!");
    }
}
