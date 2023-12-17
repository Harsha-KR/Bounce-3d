using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyMainCamera : MonoBehaviour
{
    public Transform player;
    public float smoothness;
    private Vector3 cameraOffset;
    public float speed;

    private void Start()
    {
        cameraOffset = new Vector3(0, 3.5f, -11f);
    }

    private void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }

        SetHeight();
        Move();

        if(Vector3.Distance(player.transform.position, this.transform.position) > 5f)
        {
            ResetPosition(player.position);
        }
    }

    private void SetHeight()
    {
        if (player.position.y < 7.5f)
        {
            cameraOffset.y = 3.5f;
        }
        else if(player.position.y > 7.5 && player.position.y < 14)
        {
            cameraOffset.y = 10.5f;
        }
        else if(player.position.y > 14)
        {
            cameraOffset.y = 17.5f;
        }
    }

    private void Move()
    {
        float difference = player.position.x - this.transform.position.x;

        if ((difference > -1 && difference < 2) && Mathf.Abs(this.transform.position.y - cameraOffset.y) < .01f)
        {
            return;
        }

        cameraOffset.x = player.transform.position.x;
        Vector3 direction = cameraOffset - this.transform.position; 
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }

    public void ResetPosition(Vector3 position)
    {
        Vector3 newPosition = new Vector3(position.x, cameraOffset.y, cameraOffset.z);
        this.transform.position = newPosition;
    }
}
