using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    [SerializeField] private int HPRegen;
    [SerializeField] private int arrowCount;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject arrowBonus;
    [SerializeField] private bool isPlayer;
    private float _hp;
    private static readonly int Damage = Animator.StringToHash("TakeDamage");
    private int _arrowsInside;
    private int _frags;

    // Start is called before the first frame update
    void Start()
    {
        _hp = MaxHP;
        _arrowsInside = 0;
        _frags = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _hp += HPRegen * Time.deltaTime;
        _hp = Mathf.Clamp(_hp, 0, MaxHP);
    }

    public void TakeDamage(float count, bool collectArrow)
    {
        // Debug.Log("Take damage");
        _hp -= count;
        if (collectArrow)
        {
            _arrowsInside++;
        }
        _hp = Mathf.Clamp(_hp, 0, MaxHP);
        animator.SetTrigger(Damage);
        if (_hp <= 0)
        {
            if (_arrowsInside > 0)
            {
                var loot = Instantiate(arrowBonus);
                loot.GetComponent<Bonus>().Set(BonusName.Arrows, _arrowsInside);
                loot.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }

    public float GetHPPercent()
    {
        return _hp / MaxHP;
    }
    public float GetHP()
    {
        return _hp;
    }
    public bool IsAlive()
    {
        return _hp > 0;
    }

    public void TakeBonus(BonusName bonusName, int value)
    {
        switch (bonusName)
        {
            case BonusName.Arrows:
                arrowCount += value;
                break;
            case BonusName.Health:
                _hp += value;
                _hp = Mathf.Clamp(_hp, 0, MaxHP);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(bonusName), bonusName, null);
        }
    }
    
    public int GetArrowCount()
    {
        return arrowCount;
    }

    public int GetFrags()
    {
        return _frags;
    }

    public void UseArrow()
    {
        arrowCount--;
    }

    public void AddFrag()
    {
        _frags++;
    }

    public bool CanAttack(HealthStats other)
    {
        return other.isPlayer != isPlayer;
    }
}
