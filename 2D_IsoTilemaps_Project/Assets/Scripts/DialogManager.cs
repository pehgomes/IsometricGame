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

    void FixedUpdate(){
        if(timeout > 0){
            timeout--;
            if(timeout == 0){
                dialogBox.anim.SetBool("IsOpen", false);
            }
        }
    }

    void ClickConfirm(){
        switch(lastClicked){
            case "laptop_SW":
                hud.updateBars(0.01f, 0.05f, 0.00f, 0.05f, 0.00f);
                break;
        }

        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void ClickCancel(){
        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    public void Click(string name, Vector3 position){
        lastClicked = name;

        dialogBox.dialogText.text = "É um " +name +" na posição " +position.ToString() +".";
        dialogBox.dialogText.text += "\nPlayer está na posição " +player.position.ToString() +".";
        dialogBox.dialogText.text += "\nPlayer está a uma distância de " +Vector3.Distance( player.position, position) +".";

        dialogBox.confirmButton.GetComponentInChildren<Text>().text = "Usar";
        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";

        dialogBox.anim.SetBool("IsOpen", true);
        timeout = 300;
    }

}
