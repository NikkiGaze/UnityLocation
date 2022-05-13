﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;
    [SerializeField] private Animator animator;
    private List<HealthStats> _enemiesCanAttack;
    private float _lastAttackTime;
    private static readonly int Attack = Animator.StringToHash("MeleeAttack");

    // Start is called before the first frame update
    void Start()
    {
        _enemiesCanAttack = new List<HealthStats>();
        _lastAttackTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TryAttack()
    {
        var currentTime = Time.time;
        if (currentTime - _lastAttackTime < cooldown)
        {
            return;
        }

        _lastAttackTime = currentTime;
        
        animator.SetTrigger(Attack);
        if (_enemiesCanAttack.Count > 0)
        {
            _enemiesCanAttack[0].TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        HealthStats stats = other.gameObject.GetComponent<HealthStats>();
        if (stats)
        {
            _enemiesCanAttack.Add(stats);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        HealthStats stats = other.gameObject.GetComponent<HealthStats>();
        if (stats && _enemiesCanAttack.Contains(stats))
        {
            _enemiesCanAttack.Remove(stats);
        }
    }
}
