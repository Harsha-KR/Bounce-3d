using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpawnManager _spawnner;
    bool isDead;
    Rigidbody PlayerRb;
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float JumpForce;
    Vector3 m_EulerAngleVelocity;
    [SerializeField]
    Material CollectableAfter;
    [SerializeField]
    GameObject CheckpointSpawnner;


    void Start()
    {
        _spawnner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        isDead = false;
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

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Collectable":
                other.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;
                other.gameObject.GetComponent<SphereCollider>().enabled = false;
                //add +100 to score
                break;
            case "PowerUp":
                Destroy(other.gameObject);
                //add +1 to total lives
                break;
            case "Checkpoint":
                Vector3 _Position = other.gameObject.transform.position;
                Destroy(other.gameObject);
                Instantiate(CheckpointSpawnner, _Position, Quaternion.Euler(-90, 0, 0));
                break;
        
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                DeathLogic();
                break;
        }
    }

    private void DeathLogic()
    {
        if (!isDead)
        {
            isDead = true;
            Destroy(this.gameObject);
            _spawnner.spawnner();
            
        }
    }
}
