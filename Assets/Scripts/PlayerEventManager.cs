using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public delegate void CollectedCollectable(Collider any);
    public static event CollectedCollectable Collectable;
    public static event CollectedCollectable Lives;
    public static event CollectedCollectable Checkpoint;
    bool isDead;

    public delegate void PlayerDied();
    public static event PlayerDied Dead;
    private void Start()
    {
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Collectable":
                Collectable?.Invoke(other);
                break;
            case "Lives":
                Lives?.Invoke(other);
                break;
            case "Checkpoint":
                Checkpoint?.Invoke(other);
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
            Dead?.Invoke();          
        }
    }
}
