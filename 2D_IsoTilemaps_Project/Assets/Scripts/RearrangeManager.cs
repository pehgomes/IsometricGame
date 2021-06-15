using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeManager : MonoBehaviour
{
    public GameObject salaDesarrumada;
    public GameObject salaArrumada;

    public GameObject janelaFechada;
    public GameObject janelaAberta;

    public GameObject portaFechada;
    public GameObject portaAberta;

    public void arrumarSala()
    {
	salaDesarrumada.SetActive(false);
	salaArrumada.SetActive(true);
    }

    public void abrirJanela()
    {
	janelaFechada.SetActive(false);
	janelaAberta.SetActive(true);
    }

    public void abrirPorta()
    {
	portaFechada.SetActive(false);
	portaAberta.SetActive(true);
    }

}
