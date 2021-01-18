using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public delegate void CollectedCollectable(int _Points);
    public static event CollectedCollectable UpdateScoreUI;

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
        UpdateScoreUI?.Invoke(Points);
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;

        //add +100 to score
    }

}
