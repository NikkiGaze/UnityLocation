using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;
    [SerializeField] private Animator animator;
    [SerializeField] private HealthStats stats;
    private List<HealthStats> _enemiesCanAttack;
    private float _lastAttackTime;
    private static readonly int Attack = Animator.StringToHash("MeleeAttack");

    // Start is called before the first frame update
    void Start()
    {
        _enemiesCanAttack = new List<HealthStats>();
        _lastAttackTime = 0.0f;
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

        // Debug.Log(_enemiesCanAttack.Count);
        _enemiesCanAttack = _enemiesCanAttack.Where(item => item != null && item.IsAlive()).ToList();
        
        if (_enemiesCanAttack.Count > 0)
        {
            _enemiesCanAttack[0].TakeDamage(damage, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        HealthStats otherStats = other.gameObject.GetComponent<HealthStats>();
        if (!otherStats)
        {
            return;
        }

        // Debug.Log(stats.CanAttack(otherStats));
        if (stats.CanAttack(otherStats))
        {
            _enemiesCanAttack.Add(otherStats);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("exit");
        var stats = GetComponent<HealthStats>();
        if (stats && _enemiesCanAttack.Contains(stats))
        {
            _enemiesCanAttack.Remove(stats);
        }
    }
}
