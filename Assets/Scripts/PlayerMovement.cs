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
    Vector3 m_EulerAngleVelocity;
    bool isMoving;
    [SerializeField]
    bool isOnSlope;
        
    void Start()
    {
        isOnSlope = false;
        m_EulerAngleVelocity = new Vector3(0, 0, RotationSpeed);
        PlayerRb = GetComponent<Rigidbody>();
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
        isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (isMoving && !isOnSlope)
        {
            Vector3 newPosition = PlayerRb.position + (Vector3.right * HorizontalInput * MovementSpeed * Time.deltaTime);

            PlayerRb.MovePosition(newPosition);

            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * -HorizontalInput);
            PlayerRb.MoveRotation(PlayerRb.rotation * deltaRotation);
        }
        else if(isMoving && isOnSlope)
        {
            Physics.gravity = Vector3.zero;
                       
            
            Vector3 test = new Vector3(HorizontalInput, 1, 0);
            
            Vector3 newPosition = PlayerRb.position + (test * MovementSpeed * Time.deltaTime);

            PlayerRb.MovePosition(newPosition);

            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * -HorizontalInput);
            PlayerRb.MoveRotation(PlayerRb.rotation * deltaRotation);
        }
        else
        {
            PlayerRb.angularVelocity = Vector3.zero;
            
        }
         
        if(!isOnSlope)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {            
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Force);
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
}
