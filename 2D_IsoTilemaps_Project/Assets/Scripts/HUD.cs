using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GenericBar energia;
    public GenericBar motivacao;
    public GenericBar diversao;
    public GenericBar socializacao;
    public GenericBar autocuidados;

    // Start is called before the first frame update
    void Start()
    {
        this.updateBars(0.2f, 0.15f, 0.15f, 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBars(float b1, float b2, float b3, float b4, float b5)
    {
        energia.IncrementValue(b1);
        motivacao.IncrementValue(b2);
        diversao.IncrementValue(b3);
        socializacao.IncrementValue(b4);
        autocuidados.IncrementValue(b5);
    }

    public float[] getAllBars()
    {
	return new[]{energia.slider.value, motivacao.slider.value, diversao.slider.value, socializacao.slider.value, autocuidados.slider.value};
    }

}
