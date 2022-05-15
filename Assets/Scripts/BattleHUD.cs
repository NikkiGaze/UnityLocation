using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private Text heroHP;
    [SerializeField] private Text score;
    [SerializeField] private Text arrowCount;

    [SerializeField] private HealthStats hero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heroHP.text = hero.GetHP().ToString();
        arrowCount.text = hero.GetArrowCount().ToString();
        score.text = hero.GetFrags().ToString();
    }
}
