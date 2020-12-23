using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody PlayerRb;
    [SerializeField]
    float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            Vector3 newPosition = PlayerRb.position + (Vector3.right * HorizontalInput * MovementSpeed * Time.deltaTime);

            PlayerRb.MovePosition(newPosition);
        }
    }
}
