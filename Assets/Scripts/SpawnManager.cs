using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    int lives;

    public int Lives
    {
        get
        {
            return lives;
        }
    }

    Vector3 SpawnPosition;

    private void OnEnable()
    {
        PlayerEventManager.Checkpoint += UpdateSpawnPosition;
        PlayerEventManager.Dead += spawnner;
        PlayerEventManager.Lives += LivesCollected;
    }
    private void OnDisable()
    {
        PlayerEventManager.Checkpoint -= UpdateSpawnPosition;
        PlayerEventManager.Dead -= spawnner;
        PlayerEventManager.Lives -= LivesCollected;
    }
    private void Start()
    {
        lives = 4;
        SpawnPosition = this.gameObject.transform.position;
        Instantiate(Player, SpawnPosition,Quaternion.identity);       
    }

    private void UpdateSpawnPosition(Collider other)
    {
        SpawnPosition = other.transform.position;
        
    }
    private void spawnner()
    {
        lives--;
        if (lives > 0)
        {
            Instantiate(Player, SpawnPosition, Quaternion.identity);            
        }
    }

    //since this method has no other function than destroying the object, did not find any reason to create a seperate script. 
    //If in future it has more functions, then think about a seperate script. 

    private void LivesCollected(Collider other)
    {
        Destroy(other.gameObject);
        lives++;
        
    }
}
