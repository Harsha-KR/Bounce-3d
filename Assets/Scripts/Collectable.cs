using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    Material CollectableAfter;

    public void Collected()
    {
        SpawnManager._Instance.score += 100;
        this.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;        
    }
}
