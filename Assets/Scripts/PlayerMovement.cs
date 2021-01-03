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
    
    void Start()
    {        
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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = PlayerRb.position + (Vector3.right * HorizontalInput * MovementSpeed * Time.deltaTime);

            PlayerRb.MovePosition(newPosition);

            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * -HorizontalInput);
            PlayerRb.MoveRotation(PlayerRb.rotation * deltaRotation);
        }
        else
        {
            PlayerRb.angularVelocity = Vector3.zero;
            
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {            
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Force);
        }
    }   
    
}
