using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bonusPrefab;
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
        if (currentTime - _lastSpawnTime >= cooldown && transform.childCount == 0)
        {
            var bonus = Instantiate(bonusPrefab, transform);
            bonus.GetComponent<Bonus>().Set(BonusName.Health, 20);
            _lastSpawnTime = currentTime;
        }
    }
}
