using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    SpawnManager _spawnManager;

    bool isPumped;

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
                SpawnManager._Instance.score += 500;
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
            case "PumpIn":
                PumpIn();
                break;
            case "PumpOut":
                PumpOut();
                Debug.Log("Test");
                break;
        }
    }

    private void PumpOut()
    {
        if (isPumped)
        {
            this.gameObject.transform.localScale = Vector3.one;
            isPumped = false;
        }
    }

    private void PumpIn()
    {
        if (!isPumped)
        {
            this.gameObject.transform.localScale = Vector3.one * 1.5f;
            isPumped = true;
        }
    }

    private void DeathLogic()
    {
        if (!_isDead)
        {
            _isDead = true;
            Destroy(this.gameObject);
            _spawnManager.Spawnner();
        }
    }
}
