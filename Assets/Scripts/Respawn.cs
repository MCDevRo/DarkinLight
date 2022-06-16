using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Player2;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform respawnPointBlack;
    public GameObject whiteDeath;
    public GameObject blackDeath;
    private float delay = 0.2f;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("White"))
        {
            FindObjectOfType<AudioManager>().Play("fallDeath");
            //Instantiate(whiteDeath, transform.position, transform.rotation);
            StartCoroutine(RespawnPlayers(delay));
        }
        else if (other.gameObject.CompareTag("Black"))
        {
            FindObjectOfType<AudioManager>().Play("fallDeath");
            //Instantiate(blackDeath, transform.position, transform.rotation);
            StartCoroutine(RespawnPlayers(delay));
        }
        
    }
    IEnumerator RespawnPlayers(float delay)
    {
        Instantiate(whiteDeath, respawnPoint.position, respawnPoint.rotation);
        Instantiate(blackDeath, respawnPointBlack.position, respawnPointBlack.rotation);
        yield return new WaitForSeconds(0.2f);
        Player.transform.position = respawnPoint.transform.position;
        Player2.transform.position = respawnPointBlack.transform.position;
    }
 
}
