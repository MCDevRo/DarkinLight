using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSwitching : MonoBehaviour
{
    private PlayerBlackControl blackPlayer;
    private PlayerWhiteControl whitePlayer;
    public bool whitePlayerOn = true;
    public CinemachineVirtualCamera playerWhiteCam;
    public CinemachineVirtualCamera playerBlackCam;
    // Start is called before the first frame update
    void Start()
    {
        blackPlayer = GameObject.FindGameObjectWithTag("Black").GetComponent<PlayerBlackControl>();
        whitePlayer = GameObject.FindGameObjectWithTag("White").GetComponent<PlayerWhiteControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Switch();
        }
        if(whitePlayer == null)
        {
            whitePlayerOn = false;
        }
        if (blackPlayer == null )
        {
            whitePlayerOn = true;
        }
        if (whitePlayer.isGrounded && !whitePlayerOn && !whitePlayer.isParent && whitePlayer != null)
        {
            whitePlayer.rb.velocity = Vector3.zero;

        }
        if(blackPlayer.isGrounded && whitePlayerOn && !blackPlayer.isParent && blackPlayer != null)
        {
            blackPlayer.rb.velocity = Vector3.zero;
        }
    }

    public void Switch()
    {
        if (whitePlayerOn)
        {
            playerWhiteCam.enabled = false;
            playerBlackCam.enabled = true;
            whitePlayerOn = false;
            if(whitePlayer.isGrounded && whitePlayer != null)
            {
                whitePlayer.rb.velocity = Vector3.zero;
            } 
            
        }
        else
        {
            playerWhiteCam.enabled = true;
            playerBlackCam.enabled = false;
            whitePlayerOn = true;
            if(blackPlayer.isGrounded && blackPlayer != null)
            {
                blackPlayer.rb.velocity = Vector3.zero;
            }
        }
    }
}
