using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   [SerializeField]
    GameObject spawnManager;
       

    [SerializeField]
    GameObject CheckpointSpawnner;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            CheckpointCollected(other);
    }
    
    private void CheckpointCollected(Collider other)
    {        
       
        Destroy(this.gameObject);
        Instantiate(CheckpointSpawnner, this.transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
