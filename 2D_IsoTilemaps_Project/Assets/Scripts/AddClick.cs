using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClick : MonoBehaviour
{

    public DialogManager dialogManager;
	
    private UIHoverListener uiListener;

    public string defaultMessage = "";
    public string basicMessage = "";
    public string mediumMessage = "";
    public string expertMessage = "";

    public string button1Text = "";
    public string button1Req = "";
    public string button2Text = "";
    public string button2Req = "";
    public string button3Text = ""; 
    public string button3Req = "";   

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
	   this.dialogManager.Click(this.gameObject, new[]{button1Text, button1Req}, new[]{button2Text, button2Req}, new[]{button3Text, button3Req}, new[]{defaultMessage, basicMessage, mediumMessage, expertMessage});
	}
    }

}
