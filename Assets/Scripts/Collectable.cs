using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    Material CollectableAfter;
    int Points = 500;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))            
            Collected();            
    }

    private void Collected()
    {
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;
    }

}
