using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    Material CollectableAfter;

    public void Collected()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = CollectableAfter;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        //add score
    }
}
