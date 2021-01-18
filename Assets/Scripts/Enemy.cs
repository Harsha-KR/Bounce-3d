using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void CollisionEvent();
    public static event CollisionEvent EnemyContact;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            EnemyContact?.Invoke();
    }
}
