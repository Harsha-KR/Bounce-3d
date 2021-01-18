using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikey : MonoBehaviour
{
    float speed;
    [SerializeField]
    Vector3 pos1;
    [SerializeField]
    Vector3 pos2;

    private void Start()
    {
        speed = Random.Range(1f, 2.5f);
        pos1 = this.transform.position;
        pos2 = this.transform.position + new Vector3(0f, 4f, 0f);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
