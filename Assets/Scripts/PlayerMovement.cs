using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{        
    Rigidbody PlayerRb;
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float JumpForce;
    [SerializeField]
    bool isOnSlope;
    Animator _animation;
    [SerializeField]
    float MaxVelocity;

    [SerializeField]
    bool isPumped;

    void Start()
    {
        _animation = this.gameObject.GetComponent<Animator>();
        isPumped = false;
        isOnSlope = false;
        PlayerRb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
        
    }

    private void Update()
    {
        Jump();
    }

    private void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D) && !isOnSlope)
        {
            if (PlayerRb.velocity.x < MaxVelocity)
            {
                Vector3 _MovementVector = Vector3.right * HorizontalInput * MovementSpeed;
                PlayerRb.AddForce(_MovementVector, ForceMode.Acceleration);
            }
        }
        else if (Input.GetKey(KeyCode.A) && !isOnSlope)
        {
            if (PlayerRb.velocity.x > -MaxVelocity)
            {
                Vector3 _MovementVector = Vector3.right * HorizontalInput * MovementSpeed;
                PlayerRb.AddForce(_MovementVector, ForceMode.Acceleration);
            }    
        }
        else if (Input.GetKey(KeyCode.D) && isOnSlope)
        {
            if (PlayerRb.velocity.x < MaxVelocity/2 && PlayerRb.velocity.y < MaxVelocity/2)
            {
                Vector3 _MovementVector = new Vector3( HorizontalInput * MovementSpeed, HorizontalInput * MovementSpeed, 0);
                PlayerRb.AddForce(_MovementVector, ForceMode.Acceleration);
            }
        }
        else if (Input.GetKey(KeyCode.A) && isOnSlope)
        {
            if (PlayerRb.velocity.x > -MaxVelocity / 2 && PlayerRb.velocity.y < MaxVelocity / 2)
            {
                Vector3 _MovementForce = new Vector3(HorizontalInput * MovementSpeed, -HorizontalInput * MovementSpeed, 0);
                PlayerRb.AddForce(_MovementForce, ForceMode.Acceleration);
            }
        }
        else
        {
            PlayerRb.angularVelocity = Vector3.zero;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Acceleration);
        }
    }

    private void OnCollisionStay(Collision collision)
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



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PumpIn")
        {
            PumpIn();
        }
    }

    private void PumpIn()
    {

        if (!isPumped)
        {
            _animation.Play("PlayerPumpIn");
            isPumped = true;
            
        }
    }
}
