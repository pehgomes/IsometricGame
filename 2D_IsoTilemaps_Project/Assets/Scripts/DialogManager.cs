using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public DialogBox dialogBox;
    public HUD hud;
    public Button buttonWardrobe;
    public Button buttonPC;
    public Button buttonBed;

    int lastClicked = -1;

    int timeout = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.confirmButton.onClick.AddListener(ClickConfirm);
        dialogBox.cancelButton.onClick.AddListener(ClickCancel);

		buttonWardrobe.onClick.AddListener(ClickWardrobe);
		buttonPC.onClick.AddListener(ClickPC);
		buttonBed.onClick.AddListener(ClickBed);
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
            case 1:
                hud.updateBars(0.01f, 0.05f, 0.00f, 0.05f, 0.00f);
                break;
            case 2:
                hud.updateBars(0.01f, 0.00f, 0.05f, 0.00f, 0.05f);
                break;
            case 3:
                hud.updateBars(0.00f, -0.03f, -0.03f, -0.03f, -0.03f);
                break;
        }

        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void ClickCancel(){
        timeout = 0;
        dialogBox.anim.SetBool("IsOpen", false);
    }

    void ClickWardrobe(){
        lastClicked = 1;

        dialogBox.dialogText.text = "É um armário.";
        dialogBox.confirmButton.GetComponentInChildren<Text>().text = "Abrir";
        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";

        dialogBox.anim.SetBool("IsOpen", true);
        timeout = 300;
    }

    void ClickPC(){
        lastClicked = 2;

        dialogBox.dialogText.text = "É um computador.";
        dialogBox.confirmButton.GetComponentInChildren<Text>().text = "Usar";
        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";

        dialogBox.anim.SetBool("IsOpen", true);
        timeout = 300;
    }

    void ClickBed(){
        lastClicked = 3;

        dialogBox.dialogText.text = "É uma cama.";
        dialogBox.confirmButton.GetComponentInChildren<Text>().text = "Dormir";
        dialogBox.cancelButton.GetComponentInChildren<Text>().text = "Cancelar";

        dialogBox.anim.SetBool("IsOpen", true);
        timeout = 300;
    }
}
