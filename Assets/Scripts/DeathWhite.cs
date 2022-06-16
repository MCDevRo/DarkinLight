using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWhite : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Player2;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform respawnPointBlack;
    public GameObject whiteDeath;
    public GameObject blackDeath;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(whiteDeath, respawnPoint.position, respawnPoint.rotation);
        Instantiate(blackDeath, respawnPointBlack.position, respawnPointBlack.rotation);
        FindObjectOfType<AudioManager>().Play("mobDeath");
        if (other.gameObject.CompareTag("White"))
            Player.transform.position = respawnPoint.transform.position;
        Player2.transform.position = respawnPointBlack.transform.position;
       
    }
   
}

