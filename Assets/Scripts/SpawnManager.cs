using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _Instance;
    public MyMainCamera myMainCamera;

    [SerializeField]
    GameObject Player;
    [SerializeField]
    public int lives;

    public int score;

    Vector3 SpawnPosition;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 70;

        score = 000;
        myMainCamera = FindObjectOfType<MyMainCamera>();
    }
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        lives = 5;
        SpawnPosition = this.gameObject.transform.position;
        Spawnner();
    }

    public void UpdateSpawnPosition(Collider other)
    {
        SpawnPosition = other.transform.position;
        
    }    
    public void Spawnner()
    {
        lives--;
        if (lives > 0)
        {
            var go = Instantiate(Player, SpawnPosition, Quaternion.identity);
            myMainCamera.player = go.transform;
            myMainCamera.ResetPosition(go.transform.position);
        }
    }
    public void LivesCollected(Collider other)
    {
        Destroy(other.gameObject);
        lives++;        
    }

    public IEnumerator StartGameRoutinef()
    {
        yield return new WaitForSeconds(1f);
        StartGame();
    }
}
