using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    [SerializeField] private int HPRegen;
    [SerializeField] private Animator animator;

    public float _hp;

    private static readonly int Damage = Animator.StringToHash("TakeDamage");

    // Start is called before the first frame update
    void Start()
    {
        _hp = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        _hp += HPRegen * Time.deltaTime;
        _hp = Mathf.Clamp(_hp, 0, MaxHP);
    }

    public void TakeDamage(float count)
    {
        _hp -= count;
        _hp = Mathf.Clamp(_hp, 0, MaxHP);
        animator.SetTrigger(Damage);
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
