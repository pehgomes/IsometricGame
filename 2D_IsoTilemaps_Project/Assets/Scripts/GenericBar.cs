using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // public float test = 0.5f;
    // float aux = 1;

    void Start()
    {
        
    }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     if(test <= 0f || test >= 1f){
    //         aux *= -1;
    //     }
        
    //     test += 0.005f * aux;

    //     SetValue(test);
    // }

    public void SetValue(float newValue){
        slider.value = newValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
    public void IncrementValue(float value){
        slider.value += value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
