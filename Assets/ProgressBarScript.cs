using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxCooldown(float cooldown)
    {
        slider.maxValue = cooldown;
        slider.value = cooldown;
    }

    public void SetCooldown(float cooldown)
    {
        slider.value = cooldown;
    }


    public void ShowSlider()
    {
        slider.gameObject.SetActive(true);
    }

    public void HideSlider()
    {
        slider.gameObject.SetActive(false);
    }
}
