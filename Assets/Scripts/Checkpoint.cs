using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public delegate void TriggerEvent(Vector3 SpawnPosition);
    public static event TriggerEvent NewSpawnPosition;

    [SerializeField]
    GameObject CheckpointSpawnner;

    Vector3 _newSpawnPosition;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            CheckpointCollected();
    }
    
    private void CheckpointCollected()
    {
            _newSpawnPosition = this.gameObject.transform.position;
            Destroy(this.gameObject);
            Instantiate(CheckpointSpawnner, _newSpawnPosition, Quaternion.Euler(-90, 0, 0));
            NewSpawnPosition?.Invoke(_newSpawnPosition);
    }
}
