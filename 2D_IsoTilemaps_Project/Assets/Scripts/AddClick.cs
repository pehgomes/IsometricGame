using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClick : MonoBehaviour
{

    public DialogManager dialogManager;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
	this.dialogManager.Click(this.gameObject);
    }

}
