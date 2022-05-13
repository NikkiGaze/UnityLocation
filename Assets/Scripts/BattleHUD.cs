using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private Text heroHP;
    [SerializeField] private Text enemyHP;

    [SerializeField] private HealthStats hero;
    [SerializeField] private HealthStats enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heroHP.text = hero._hp.ToString();
        enemyHP.text = enemy._hp.ToString();
    }
}
