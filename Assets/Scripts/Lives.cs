using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{
    public delegate void TriggerEvents();
    public static event TriggerEvents LivesCollected;

    private void _LivesCollected()
    {
        LivesCollected?.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _LivesCollected();
        }
    }


}
