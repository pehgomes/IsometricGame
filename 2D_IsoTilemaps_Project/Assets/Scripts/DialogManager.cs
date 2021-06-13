using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	if(values[0] == 0f && values[1] < 0.5f && values[2] < 0.5f && values[3] < 0.5f && values[4] < 0.5f){
            SceneManager.LoadScene(2);
	}
	else if(values[1] > 0.35f && values[4] > 0.35f && objectiveBasic == false)
	{
	    objectiveBasic = true;
	    dialogBox.dialogText.text = "Objetivo Básico!";

	    dialogBox.button1.gameObject.SetActive(false);
	    dialogBox.button2.gameObject.SetActive(false);
	    dialogBox.button3.gameObject.SetActive(false);

	    dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Confirmar";
	
            dialogBox.anim.SetBool("IsOpen", true);
	
	}
	
    }

    void Click1()
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
	
        dialogBox.anim.SetBool("IsOpen", false);
	CheckObjectives();
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
                hud.updateBars(-1f, -1f, -1f, -1f, -1f);
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

        dialogBox.anim.SetBool("IsOpen", false);
	CheckObjectives();
    }

    void Click3()
    {
        dialogBox.anim.SetBool("IsOpen", false);
	CheckObjectives();
    }

    void ClickCancel()
    {
        dialogBox.anim.SetBool("IsOpen", false);
    }

    public void Click(GameObject obj, string[] b1, string[] b2, string[] b3, string[] messages)
    {
	
	float distance = Vector3.Distance(player.position, obj.transform.position);
	
	dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";

        if(timeout == 0)
	{
	    if(distance < 1.5)
	    {
                lastClicked = obj.name;

                //dialogBox.dialogText.text = "É um " + obj.name + " na posição " + obj.transform.position.ToString() + ".";
                //dialogBox.dialogText.text += "\nPlayer está na posição " + player.position.ToString() + ".";
                //dialogBox.dialogText.text += "\nPlayer está a uma distância de " + distance + ".";
		
		dialogBox.dialogText.text = messages[0];
		if(objectiveBasic && messages[1] != "")
		    dialogBox.dialogText.text = messages[1];
		if(objectiveMedium && messages[2] != "")
		    dialogBox.dialogText.text = messages[2];
		if(objectiveExpert && messages[3] != "")
		    dialogBox.dialogText.text = messages[3];

	        dialogBox.button1.gameObject.SetActive(false);
	        if(b1[0] != "" &&
	        ((b1[1] == "") ||
	        (b1[1] == "Basic" && objectiveBasic) || 
	        (b1[1] == "Medium" && objectiveMedium) ||
	        (b1[1] == "Expert" && objectiveExpert)))
	        {	
	            dialogBox.button1.gameObject.SetActive(true);
	            dialogBox.button1.GetComponentInChildren<Text>().text = b1[0];
	        }

	        dialogBox.button2.gameObject.SetActive(false);
	        if(b2[0] != "" &&
	        ((b2[1] == "") ||
	        (b2[1] == "Basic" && objectiveBasic) || 
	        (b2[1] == "Medium" && objectiveMedium) ||
	        (b2[1] == "Expert" && objectiveExpert)))
	        {	
	            dialogBox.button2.gameObject.SetActive(true);
	            dialogBox.button2.GetComponentInChildren<Text>().text = b2[0];
	        }

	        dialogBox.button3.gameObject.SetActive(false);
	        if(b3[0] != "" &&
	        ((b3[1] == "") ||
	        (b3[1] == "Basic" && objectiveBasic) || 
	        (b3[1] == "Medium" && objectiveMedium) ||
	        (b3[1] == "Expert" && objectiveExpert)))
	        {	
	            dialogBox.button3.gameObject.SetActive(true);
	            dialogBox.button3.GetComponentInChildren<Text>().text = b3[0];
	        }
        
	    }
	    else
	    {
	        dialogBox.dialogText.text = "Muito longe!";
	        dialogBox.button1.gameObject.SetActive(false);
	        dialogBox.button2.gameObject.SetActive(false);
	        dialogBox.button3.gameObject.SetActive(false);
	        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Ok";
	    }

        dialogBox.anim.SetBool("IsOpen", true);

	}

    }

        

}
