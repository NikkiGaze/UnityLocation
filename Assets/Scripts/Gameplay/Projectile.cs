using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private Vector3 _directionVector;
    private bool _isShot;
    private float _damage;
    // Start is called before the first frame update
    void Start()
    {
        _isShot = false;
        _directionVector = (endPoint.position - startPoint.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isShot)
        {
            transform.localPosition = transform.position + _directionVector * speed * Time.deltaTime;
        }
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isShot)
        {
            return;
        }

        HealthStats stats = other.gameObject.GetComponent<HealthStats>();
        if (stats)
        {
            stats.TakeDamage(_damage, true);
            transform.parent = stats.transform;
            _isShot = true;
        }
    }
}
