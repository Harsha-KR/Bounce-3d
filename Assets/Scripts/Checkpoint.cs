using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    GameObject CheckpointSpawnner;
    private void OnEnable()
    {
        PlayerEventManager.Checkpoint += CheckpointCollected;
    }
    private void OnDisable()
    {
        PlayerEventManager.Checkpoint -= CheckpointCollected;
    }
    private void CheckpointCollected(Collider Same)
    {
        Vector3 _Position = Same.gameObject.transform.position;
        Destroy(Same.gameObject);
        Instantiate(CheckpointSpawnner, _Position, Quaternion.Euler(-90, 0, 0));
    }
}
