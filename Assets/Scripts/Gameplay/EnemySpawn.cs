using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float cooldown;

    private float _lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        _lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - _lastSpawnTime >= cooldown)
        {
            var enemy = Instantiate(enemyPrefab, transform);
            enemy.GetComponent<EnemyConroller>().SetPlayerReference(player);
            _lastSpawnTime = currentTime;
        }
    }
}
