using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    SpawnManager _spawnManager;

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
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        _isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Collectable":
                other.gameObject.GetComponent<Collectable>().Collected();
                break;
            case "Lives":
                _spawnManager.LivesCollected(other);
                break;
            case "Checkpoint":
                other.GetComponent<Checkpoint>().CheckpointCollected(other);
                _spawnManager.UpdateSpawnPosition(other);
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
                
                break;
            case "PumpIn":
                
                break;
            case "PumpOut":
                
                break;
        }
    }

    private void DeathLogic()
    {
        if (!_isDead)
        {
            _isDead = true;
            Destroy(this.gameObject);
            _spawnManager.spawnner();
        }
    }
}
