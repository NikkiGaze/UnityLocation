using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    [SerializeField] private PlayerController playerReference;
    [SerializeField] private PlayerFollower movementController;
    [SerializeField] private MeleeAttack attackController;
    // Start is called before the first frame update
    void Start()
    {
        movementController.SetTarget(playerReference.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (movementController.CanReachPlayer())
        {
            attackController.TryAttack();
        }
    }
    public void SetPlayerReference(PlayerController player)
    {
        playerReference = player;
        movementController.SetTarget(playerReference.transform);
    }
    private void OnDestroy()
    {
        playerReference.AddFrag();
    }
}
