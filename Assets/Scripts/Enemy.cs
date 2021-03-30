using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bounce3D
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        GameObject SpawnManagerRef;
        SpawnManager spawnManager;

        private void Awake()
        {
            spawnManager = SpawnManagerRef.GetComponent<SpawnManager>();
        }

        private void DeathLogic(Collision other)
        {                           
                Destroy(other.gameObject);
                other.gameObject.GetComponent<Collider>().enabled = false;
            spawnManager.LivesLost();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DeathLogic(collision);
            }
        }
    }
}
