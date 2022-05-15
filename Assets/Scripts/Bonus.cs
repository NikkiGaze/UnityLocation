using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BonusName
{
    Arrows,
    Health
}

public class Bonus : MonoBehaviour
{
    [SerializeField] private BonusName name;
    [SerializeField] private int value;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Set(BonusName _name, int _value)
    {
        name = _name;
        value = _value;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            Debug.Log("Taken");
            player.TakeBonus(name, value);
            Destroy(gameObject);
        }
    }
}
