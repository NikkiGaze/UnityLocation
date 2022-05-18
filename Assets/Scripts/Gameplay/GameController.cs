using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private List<EnemySpawn> enemySpawns;
    [SerializeField] private float enemySpawncooldown;
    [SerializeField] private int maxEnemyCount;
    
    private float _lastSpawnTime;
    private int _enemyCount;
    private bool isGameFinished;
    // Start is called before the first frame update
    void Start()
    {
        isGameFinished = false;
        _lastSpawnTime = 0;
        _enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameFinished)
        {
            return;
        }
        float currentTime = Time.time;
        if (currentTime - _lastSpawnTime >= enemySpawncooldown)
        {
            foreach (var spawn in enemySpawns)
            {
                if (_enemyCount < maxEnemyCount)
                {
                    spawn.Spawn(this);
                    _enemyCount++;
                }
            }
            _lastSpawnTime = currentTime;
        }
    }

    public void Kill(HealthStats stats)
    {
        if (stats.isPlayer)
        {
            isGameFinished = true;
        }
        else
        {
            _enemyCount--;
            
            player.AddFrag();
        }
        Destroy(stats.gameObject);
    }
}
