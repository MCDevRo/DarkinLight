using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLinkBlack : MonoBehaviour
{
    //public GameObject otherPlayer;
    private Transform currentPlayer2;
    public Transform holdSlot;
    public LayerMask playerLink;
    public bool isOnPlayer;
    public Transform playerLinkCheck;
    public float radiusCheck = 0.06f;
    public bool jumpReady;
    public float jumpTime;
    private float jumpTimeCounter;
    public float jumpForce;
    public Rigidbody2D rb;
    private PlayerSwitching playerSwitch;


    // Start is called before the first frame update
    void Start()
    {
        currentPlayer2 = GameObject.FindGameObjectWithTag("Black").GetComponent<Transform>();
        playerSwitch = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerSwitching>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
       if (  isOnPlayer = Physics2D.OverlapCircle(playerLinkCheck.position, radiusCheck, playerLink))
          
        {
            rb.mass = 0.02f;
            if (isOnPlayer && Input.GetKeyDown(KeyCode.Space) && !playerSwitch.whitePlayerOn)
            {
                
                jumpReady = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;

            }
          
            
            currentPlayer2.transform.position = holdSlot.transform.position;
            /*  if (currentPlayer2.transform.position == holdSlot.transform.position && Input.GetKeyDown(KeyCode.V))
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
