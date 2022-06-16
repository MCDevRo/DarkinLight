using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public GameObject playerwhite;
    public GameObject playerdark;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Play("winLevel");
        if (collision.gameObject.CompareTag("White"))
        {
            
            CheckKeys(collision);
        }
        else if (collision.gameObject.CompareTag("Black"))
        {
            
            CheckKeys(collision);
        }
    }
    void CheckKeys(Collider2D player)
    {
        //playerdark.GetComponent<PlayerInventory>().darkKey == 1 && playerwhite.Get
        
        
        PlayerInventory inventory = playerwhite.GetComponent<PlayerInventory>();
        PlayerInventory inventoryblack = playerdark.GetComponent<PlayerInventory>();
        if(inventory.lightKey == 1 && inventoryblack.darkKey == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

}
