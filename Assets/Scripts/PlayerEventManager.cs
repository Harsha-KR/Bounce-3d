using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    [SerializeField]
    bool _isDead;
    public bool IsDead
    {
        get
        {
            return _isDead;
        }
    }

    private void OnEnable()
    {
        Enemy.EnemyContact += DeathLogic;
    }
    private void OnDisable()
    {
        Enemy.EnemyContact -= DeathLogic;
    }

    private void Start()
    {
        _isDead = false;
    }

    private void DeathLogic()
    {
        if (!_isDead)
        {
            _isDead = true;
            Destroy(this.gameObject);
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
