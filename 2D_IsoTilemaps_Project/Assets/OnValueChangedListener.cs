using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnValueChangedListener : MonoBehaviour
{
    public InputField mainInputField;

    public void Start()
    {
        //Adds a listener to the main input field and invokes a method when the value changes.
        mainInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
	StaticValues.charName = mainInputField.text;
	Debug.Log(StaticValues.charName);
        //Debug.Log("Value Changed");
    }
}
