using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    int lives;

    Vector3 SpawnPosition;

    private void Start()
    {
        lives = 4;
        SpawnPosition = this.gameObject.transform.position;
        Instantiate(Player, SpawnPosition,Quaternion.identity);
    }

    public void UpdateSpawnPosition(Vector3 position)
    {
        SpawnPosition = position;
    }
    public void spawnner()
    {
        lives--;
        if (lives > 0)
        {
            Instantiate(Player, SpawnPosition, Quaternion.identity);
        }
    }
    public void PowerUpCollected(Collider PowerUp)
    {
        Destroy(PowerUp.gameObject);
        lives++;
    }
}
