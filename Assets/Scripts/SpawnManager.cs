using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public delegate void LivesUpdateEvent(int m_Lives);
    public static event LivesUpdateEvent UpdateLives;
    
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Checkpoint GetNewSpawnPosition;
    
    int _Lives;

    Vector3 SpawnPosition;

    private void OnEnable()
    {
        Lives.LivesCollected += LivesCollected;
        Checkpoint.NewSpawnPosition += UpdateSpawnPosition;
        Enemy.EnemyContact += Spawnner;
    }
    private void OnDisable()
    {
        Lives.LivesCollected -= LivesCollected;
        Checkpoint.NewSpawnPosition -= UpdateSpawnPosition;
        Enemy.EnemyContact -= Spawnner; 
    }

    private void Start()
    {
        _Lives = 4;
        UpdateLives?.Invoke(_Lives);
        SpawnPosition = this.gameObject.transform.position;
        Spawnner();    
        
    }

    private void UpdateSpawnPosition(Vector3 NewSpawnPosition)
    {
        SpawnPosition = NewSpawnPosition;
    }

    private void LivesCollected()
    {
        _Lives++;
        UpdateLives?.Invoke(_Lives);
    }

    private void Spawnner()
    {
        if (_Lives > 0)
        {
            Instantiate(Player, SpawnPosition, Quaternion.identity);
            _Lives--;
            UpdateLives?.Invoke(_Lives);
        }
    }
    public void Test()
    {
        _Lives++;
        UpdateLives?.Invoke(_Lives);
    }

}
