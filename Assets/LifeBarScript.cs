using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarScript : MonoBehaviour
{
    public Slider slider;
    public TankBehavior Tank;
    private int firstTankLife;

    public void RemoveHealthFromSlider(int damage)
    {
        slider.value -= damage;
    }

    public void deleteFiller()
    {
        slider.fillRect.sizeDelta = new Vector2(0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        firstTankLife = Tank.health;
        slider.maxValue = Tank.health;
        slider.SetValueWithoutNotify(Tank.health);
    }

    public void Reset()
    {
        slider.maxValue = firstTankLife;
        slider.SetValueWithoutNotify(firstTankLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
