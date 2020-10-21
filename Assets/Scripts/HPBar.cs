using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        Health.playerUpdateHP += UpdateHPSlider;
    }

    public void UpdateHPSlider(float value, float maxValue)
    {
        hpSlider.value = value;
        hpSlider.maxValue = maxValue;
    }
}
