using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLinkWhite : MonoBehaviour
{
    //public GameObject otherPlayer;
    private Transform currentPlayer;
    public Transform holdSlot;
    public bool isOnPlayer;
    public Transform playerLinkCheck;
    public float radiusCheck = 0.06f;
    public LayerMask playerLink;
    public float jumpForce;
    public Rigidbody2D rb;
    private PlayerSwitching playerSwitch;
    public bool jumpReady;
    public float jumpTime;
    private float jumpTimeCounter;



    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("White").GetComponent<Transform>();
        playerSwitch = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOnPlayer = Physics2D.OverlapCircle(playerLinkCheck.position, radiusCheck, playerLink))
        {
            rb.mass = 0.02f;
            if (isOnPlayer && Input.GetKeyDown(KeyCode.Space) && playerSwitch.whitePlayerOn)
            {
                jumpReady = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            
            currentPlayer.transform.position = holdSlot.transform.position;
            /* if (currentPlayer.transform.position == holdSlot.transform.position && Input.GetKeyDown(KeyCode.V))
             {
                 radiusCheck = 0f;

             }
             else
             {
                 radiusCheck = 0.06f;
             } */
        }
        else
        {
            rb.mass = 1f;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerLinkCheck.position, radiusCheck);
        
    }
}
   


