using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public DialogBox dialogBox;
    public HUD hud;
    public GameObject hudVisibility;
    public Transform player;
    public IsometricPlayerMovementController playerMovement;
    public SpriteRenderer fadein;

    public bool objectiveBasic = false;
    public bool objectiveMedium = false;
    public bool objectiveExpert = false;

    string lastClicked = "";

    float maxTimeout = 200;
    float timeout = 100;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.button1.onClick.AddListener(Click1);
        dialogBox.button2.onClick.AddListener(Click2);
        dialogBox.button3.onClick.AddListener(Click3);
        dialogBox.cancelButton.onClick.AddListener(ClickCancel);

    }

    void FixedUpdate()
    {
        if(timeout > 0){
	    playerMovement.movementSpeed = 0;
            timeout--;
	    Color tmp = fadein.color;
	    if(timeout < 100)
	    	tmp.a = timeout/100;
	    else
	    	tmp.a = (100 -(timeout -100))/100;
            fadein.color = tmp;

	    //Debug.Log(tmp.a);
        }
	else{	   
	    playerMovement.movementSpeed = 3;
	    hudVisibility.SetActive(true);
	}
    }

    void fade()
    {
	hudVisibility.SetActive(false);
	timeout = maxTimeout;
    }

    void CheckObjectives()
    {
	float[] values = hud.getAllBars();

	
    }

    void Click1()
    {
	CheckObjectives();
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void Click2()
    {
        switch (lastClicked)
        {
            case "bedSingle_SW":
		fade();
                hud.updateBars(0.04f, -0.15f, -0.15f, -0.15f, -0.15f);
                break;
            case "shower_SE":
                hud.updateBars(0.05f, 0.03f, 0.00f, 0.00f, 0.05f);
                break;
            case "laptop_SW":
                hud.updateBars(-0.08f, -0.30f, 0.30f, 0.12f, 0.00f);
                break;
            case "books_SE":
                hud.updateBars(-0.08f, 0.20f, 0.00f, 0.00f, 0.00f);
                break;
            case "kitchenFridge_SE":
                hud.updateBars(0.05f, -0.12f, -0.04f, 0.00f, 0.03f);
                break;
            case "televisionModern_NW":
                hud.updateBars(-0.05f, -0.10f, 0.30f, -0.05f, 0.00f);
                break;
            case "kitchenStove_NW":
                hud.updateBars(0.01f, 0.05f, 0.00f, 0.05f, 0.00f);
                break;
        }
	
	CheckObjectives();
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void Click3()
    {
	CheckObjectives();
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void ClickCancel()
    {
        dialogBox.anim.SetBool("IsOpen", false);
    }

    public void Click(GameObject obj, string text1, string text2, string text3)
    {
	
	float distance = Vector3.Distance(player.position, obj.transform.position);

        if(timeout == 0 && distance < 1.5f){
        lastClicked = obj.name;

        dialogBox.dialogText.text = "É um " + obj.name + " na posição " + obj.transform.position.ToString() + ".";
        dialogBox.dialogText.text += "\nPlayer está na posição " + player.position.ToString() + ".";
        dialogBox.dialogText.text += "\nPlayer está a uma distância de " + distance + ".";

	if(text1 == "")
	{
	    dialogBox.button1.gameObject.SetActive(false);
	}
	else
	{
	    dialogBox.button1.gameObject.SetActive(true);
	    dialogBox.button1.GetComponentInChildren<Text>().text = text1;
	}

	if(text2 == "")
	{
	    dialogBox.button2.gameObject.SetActive(false);
	}
	else
	{
	    dialogBox.button2.gameObject.SetActive(true);
	    dialogBox.button2.GetComponentInChildren<Text>().text = text2;
	}

	if(text3 == "")
	{
	    dialogBox.button3.gameObject.SetActive(false);
	}
	else
	{
	    dialogBox.button3.gameObject.SetActive(true);
	    dialogBox.button3.GetComponentInChildren<Text>().text = text3;
	}
        


	}
	else
	{
	    dialogBox.dialogText.text = "Muito longe!";
	    dialogBox.button1.gameObject.SetActive(false);
	    dialogBox.button2.gameObject.SetActive(false);
	    dialogBox.button3.gameObject.SetActive(false);
	}

        dialogBox.anim.SetBool("IsOpen", true);

    }

}
