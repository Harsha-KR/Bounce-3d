using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{        
    Rigidbody PlayerRb;
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float JumpForce;
    [SerializeField]
    Vector3 BoostedScale;

    float horizontalInput;
    bool isJumping;
    float jumpStartTime;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
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

    /*private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Slope")
        {
            isOnSlope = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Slope")
        {
            isOnSlope = false;
        }
    }

    private void PumpIn()
    {
        _animation.SetBool("isPumped", true);
    }
    private void PumpOut()
    {
        _animation.SetBool("isPumped", false);
    }*/
}
