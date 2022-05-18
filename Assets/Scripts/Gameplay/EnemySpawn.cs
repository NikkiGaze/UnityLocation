using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject enemyPrefab;
    
    public void Spawn(GameController gameController)
    {
        var enemy = Instantiate(enemyPrefab, transform);
        enemy.GetComponent<EnemyConroller>().SetPlayerReference(player);
        enemy.GetComponent<HealthStats>().SetGameController(gameController);
    }
}
