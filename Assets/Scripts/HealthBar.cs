using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    [SerializeField] private Text healthText;
    [SerializeField] private HealthStats healthSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(owner.transform.position);
        healthText.text = ((int)Mathf.Floor(healthSource.GetHP())).ToString();
    }

}
