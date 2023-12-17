using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{        
    Rigidbody PlayerRb;
    AudioSource playerSFX;
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float JumpForce;

    float horizontalInput;
    bool isJumping;
    float jumpStartTime;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerSFX = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSFX.Play();
            isJumping = true;
            jumpStartTime = Time.time;            
        }
        else if ((Time.time - jumpStartTime) > 0.2f && isJumping)
        {
            isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if ((Time.time - jumpStartTime) < 0.2f)
            {
                PlayerRb.velocity = new Vector3(PlayerRb.velocity.x, 6.5f, 0);
            }
        }
    }

    private void Movement()
    {

            PlayerRb.velocity = new Vector3(horizontalInput * MovementSpeed, PlayerRb.velocity.y, 0);

    }

    private void Jump()
    {
        if(isJumping)
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
