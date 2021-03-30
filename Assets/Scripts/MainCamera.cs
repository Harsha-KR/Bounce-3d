using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCamera : MonoBehaviour
{
    GameObject Player;
    CinemachineVirtualCamera vCam;

    private void Start()
    {        
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();        
    }

    private void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");

            if (Player != null)
            {
                vCam.Follow = Player.transform;
            }
        }

    }
}
