using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClick : MonoBehaviour
{

    public DialogManager dialogManager;
	
    private UIHoverListener uiListener;

    public string button1Text = "";
    public string button2Text = "";
    public string button3Text = "";    

    // Start is called before the first frame update
    void Start()
    {
        
         uiListener = dialogManager.GetComponent<UIHoverListener> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
	if (uiListener.isUIOverride)
        {
    	   Debug.Log ("Cancelled OnMouseDown! A UI element has override this object!");
        }
	else
	{
	   this.dialogManager.Click(this.gameObject, button1Text, button2Text, button3Text);
	}
    }

}
