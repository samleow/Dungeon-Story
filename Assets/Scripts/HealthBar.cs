using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Slider hp_Slider = null;

     public Gradient gradient;

     public Image fill;

    public void SetMaxHealth(float health)
    {
        Debug.Log("MAX"+health);
        hp_Slider.maxValue = health;
        hp_Slider.value = health;

        // for color changing in hp bar
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        Debug.Log("Set"+health);
        hp_Slider.value = health;

        // for color changing in hp bar
        fill.color = gradient.Evaluate(hp_Slider.normalizedValue);
    }
}
