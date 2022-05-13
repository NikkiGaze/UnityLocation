using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    [SerializeField] private PlayerFollower movementController;
    [SerializeField] private MeleeAttack attackController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementController.CanReachPlayer())
        {
            attackController.TryAttack();
        }
    }
}
