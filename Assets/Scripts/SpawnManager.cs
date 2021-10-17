using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _Instance;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    int lives;

    Vector3 SpawnPosition;

    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 70;
    }
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        lives = 4;
        SpawnPosition = this.gameObject.transform.position;
        Instantiate(Player, SpawnPosition, Quaternion.identity);
    }

    public void UpdateSpawnPosition(Collider other)
    {
        SpawnPosition = other.transform.position;
        
    }
    public void spawnner()
    {
        lives--;
        if (lives > 0)
        {
            Instantiate(Player, SpawnPosition, Quaternion.identity);            
        }
    }
    public void LivesCollected(Collider other)
    {
        Destroy(other.gameObject);
        lives++;        
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);
        StartGame();
    }
}
