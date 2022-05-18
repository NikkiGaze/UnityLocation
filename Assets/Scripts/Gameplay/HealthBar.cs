using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject owner;
    [SerializeField] private HealthStats healthSource;
    [SerializeField] private Image bar;

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(owner.transform.position) + new Vector3(0, 80, 0);
        bar.fillAmount = healthSource.GetHPPercent();
    }

}
