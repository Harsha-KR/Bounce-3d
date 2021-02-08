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

    float InitialJumpVelocity;
    [SerializeField]
    float InitialJumpHeight;
    [SerializeField]
    float GravityStrength;

    float StandardJumpVelocity;
    [SerializeField]
    float StandardJumpHeight;


    [SerializeField]
    bool isPumped;

    void Start()
    {
        _animation = this.gameObject.GetComponent<Animator>();
        isPumped = false;
        isOnSlope = false;
        PlayerRb = this.GetComponent<Rigidbody>();

        InitialJumpVelocity = Mathf.Sqrt(2 * GravityStrength * InitialJumpHeight);
        StandardJumpVelocity = Mathf.Sqrt(2 * GravityStrength * StandardJumpHeight);
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
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            float XVelocity = PlayerRb.velocity.x / 2;
            Vector3 VelocityVector = new Vector3(XVelocity, InitialJumpVelocity, 0);

            PlayerRb.AddForce(VelocityVector, ForceMode.VelocityChange);
        }
        if( Input.GetKeyUp(KeyCode.Space) && PlayerRb.velocity.y > StandardJumpVelocity )
        {
            float XVelocity = PlayerRb.velocity.x;
            Vector3 VelocityVector = new Vector3(XVelocity, StandardJumpVelocity, 0);

            PlayerRb.velocity =  Vector3.up * StandardJumpVelocity;
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
