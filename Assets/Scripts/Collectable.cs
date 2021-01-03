using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    Material CollectableAfter;
    private void OnEnable()
    {
        PlayerEventManager.Collectable += Collected;
    }
    private void OnDisable()
    {
        PlayerEventManager.Collectable -= Collected;   
    }

    private void Collected(Collider other)
    {
        other.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;
        other.gameObject.GetComponent<SphereCollider>().enabled = false;
        //add +100 to score
    }
}
