using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    Vector3 SpawnPosition;

    private void Start()
    {
        SpawnPosition = this.gameObject.transform.position;
        Instantiate(Player, SpawnPosition,Quaternion.identity);
    }

    public void spawnner()
    {
        Instantiate(Player, SpawnPosition, Quaternion.identity);
    }
}
