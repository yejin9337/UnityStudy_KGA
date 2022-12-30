using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _actGaugeSlider;
    private void Awake()
    {
        _hpSlider.value = 1;
        _actGaugeSlider.value = 0;
    }

    public void RenewActGauge(float value)
    {
        _actGaugeSlider.value = value * 0.01f;
    }

    public void RenewHP(int value)
    {
        _hpSlider.value = value * 0.01f;
    }
}
