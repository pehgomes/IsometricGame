using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GenericBar bar1;
    public GenericBar bar2;
    public GenericBar bar3;
    public GenericBar bar4;
    public GenericBar bar5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBars(float b1, float b2, float b3, float b4, float b5){
        bar1.IncrementValue(b1);
        bar2.IncrementValue(b2);
        bar3.IncrementValue(b3);
        bar4.IncrementValue(b4);
        bar5.IncrementValue(b5);
    }
}
