using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlackControl : MonoBehaviour
{
    //public static PlayerBlackControl instance;
    public bool isGrounded;
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    public Transform groundPosCheck;
    public LayerMask playerLink;
    public bool isParent;
    public float radiusCheck;
    public LayerMask whatIsGround;
    private PlayerSwitching playerSwitch;
    public bool jumpReady;
    public float moveInput;
    public float jumpTime;
    private float jumpTimeCounter;
    public LayerMask platformBlack;
    public bool isOnPlatformBlack;
    // Start is called before the first frame update
    void Start()
    {
        playerSwitch = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerSwitching>();
        rb = GetComponent<Rigidbody2D>();
    }

    /*private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if ((bool)Physics2D.OverlapCircle(groundPosCheck.position, 1f, playerLink))
        {
            isParent = true;
        }
        else
        {
            isParent = false;
        }
        isGrounded = Physics2D.OverlapCircle(groundPosCheck.position, radiusCheck, whatIsGround);
        isOnPlatformBlack = Physics2D.OverlapCircle(groundPosCheck.position, radiusCheck, platformBlack);
   
        if ((isGrounded && Input.GetKeyDown(KeyCode.Space) && !playerSwitch.whitePlayerOn) || (isOnPlatformBlack && Input.GetKeyDown(KeyCode.Space) && !playerSwitch.whitePlayerOn))
        {
            FindObjectOfType<AudioManager>().Play("jumpBlack");
            jumpReady = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if ((Input.GetKey(KeyCode.Space) && jumpReady && !playerSwitch.whitePlayerOn) )
        {
            if (jumpTimeCounter > 0f)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                jumpReady = false;

            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpReady = false;
        }
        if (!isParent)
        {
            if (!playerSwitch.whitePlayerOn)
            {
                moveInput = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundPosCheck.position, radiusCheck);
    }
}
