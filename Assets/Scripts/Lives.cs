using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Bounce3D
{
    public class Lives : MonoBehaviour
    {
        [SerializeField]
        GameObject SpawnManagerRef;
        SpawnManager spawnManager;

        private void Awake()
        {
            spawnManager = SpawnManagerRef.GetComponent<SpawnManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                spawnManager.LivesCollected();
                Destroy(this.gameObject);                
            }
        }
    }
}