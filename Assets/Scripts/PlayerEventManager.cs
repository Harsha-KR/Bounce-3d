using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public delegate void CollectedCollectable(Collider any);
    public static event CollectedCollectable Collectable;
    public static event CollectedCollectable Lives;
    public static event CollectedCollectable Checkpoint;
    
    public delegate void CollisionEvents();
    public static event CollisionEvents Dead;
    public static event CollisionEvents LevelFinished;

    bool _isDead;
    public bool IsDead
    {
        get
        {
            return _isDead;
        }
    }

    private void Start()
    {
        _isDead = false;
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
            case "Finish":
                LevelFinished?.Invoke();
                break;
        }
    }

    private void DeathLogic()
    {
        if (!_isDead)
        {
            _isDead = true;
            Destroy(this.gameObject);
            Dead?.Invoke();          
        }
    }
}
