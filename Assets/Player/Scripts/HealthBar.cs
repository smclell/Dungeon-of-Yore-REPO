using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //set the max health of the slider
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }
    //update slider to current health value
    public void SetHealth(int health) {
        slider.value = health;
    }
}
