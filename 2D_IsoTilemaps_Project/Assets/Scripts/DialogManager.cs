using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public DialogBox dialogBox;
    public HUD hud;
    public Transform player;

    string lastClicked = "";

    int timeout = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.confirmButton.onClick.AddListener(ClickConfirm);
        dialogBox.cancelButton.onClick.AddListener(ClickCancel);

    }

    void FixedUpdate()
    {
        /*if(timeout > 0){
            timeout--;
            if(timeout == 0){
                dialogBox.anim.SetBool("IsOpen", false);
            }
        }*/
    }

    void ClickConfirm()
    {
        switch (lastClicked)
        {
            case "bedSingle_SW":
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

        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void ClickCancel()
    {
        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    public void Click(GameObject obj)
    {

        lastClicked = obj.name;

        dialogBox.dialogText.text = "É um " + obj.name + " na posição " + obj.transform.position.ToString() + ".";
        dialogBox.dialogText.text += "\nPlayer está na posição " + player.position.ToString() + ".";
        dialogBox.dialogText.text += "\nPlayer está a uma distância de " + Vector3.Distance(player.position, obj.transform.position) + ".";

        dialogBox.confirmButton.GetComponentInChildren<Text>().text = "Usar";
        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";
        

        dialogBox.anim.SetBool("IsOpen", true);
        timeout = 300;
    }

}
