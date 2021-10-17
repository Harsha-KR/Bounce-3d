﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    GameObject CheckpointSpawnner;
   
    public void CheckpointCollected(Collider Same)
    {
        SpawnManager._Instance.score += 300;
        Vector3 _Position = Same.gameObject.transform.position;
        Destroy(Same.gameObject);
        Instantiate(CheckpointSpawnner, _Position, Quaternion.Euler(-90, 0, 0));
    }
}
