using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce3D
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        GameObject Player;
        [SerializeField]
        Checkpoint GetNewSpawnPosition;
        [SerializeField]
        GameObject UI;
        UIManager UIUpdater;

        [SerializeField]
        int _Lives;

        Vector3 SpawnPosition;

        private void Awake()
        {            
            SpawnPosition = this.gameObject.transform.position;
            UIUpdater = UI.GetComponent<UIManager>();

        }
        private void Start()
        {
            _Lives = 4;
            Spawnner();
        }

        public void LivesCollected()
        {
            _Lives++;
        }
        public void LivesLost()
        {
            _Lives--;
            Spawnner();
        }

        private void Spawnner()
        {
            if (_Lives > 0)
            {
                Instantiate(Player, SpawnPosition, Quaternion.identity);
            }
        }

        public void UpdateSpawnPosition(Collider other)
        {
            SpawnPosition = other.transform.position;
        }

    }
}
