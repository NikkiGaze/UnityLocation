using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform projectilePivot;
    [SerializeField] private HealthStats stats;
    private float _lastAttackTime;
    private static readonly int Attack = Animator.StringToHash("RangeAttack");

    void Start()
    {
        _lastAttackTime = 0.0f;
    }

    public void TryAttack()
    {
        var currentTime = Time.time;
        if (currentTime - _lastAttackTime < cooldown || stats.GetArrowCount() <= 0)
        {
            return;
        }
        
        _lastAttackTime = currentTime;
        
        animator.SetTrigger(Attack);

        var arrow = Instantiate(arrowPrefab);
        arrow.transform.position = projectilePivot.position;
        arrow.transform.rotation = projectilePivot.rotation;
        arrow.GetComponent<Projectile>().SetDamage(damage);
        stats.UseArrow();
    }
}
