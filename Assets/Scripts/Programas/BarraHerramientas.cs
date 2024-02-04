using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraHerramientas : MonoBehaviour
{
    GameManager gameManager;
    public GameObject botonBarraHerramientas;
    public GameObject ventanaManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        foreach(Programa programa in gameManager.programasComprados)
        {
            GameObject btn = Instantiate(botonBarraHerramientas, transform);
            GameObject ventana = Instantiate(programa.ventana, ventanaManager.transform);
            btn.GetComponent<Image>().sprite = programa.icon;
            btn.GetComponent<BotonHerramientas>().ventanaObjetivo = ventana;
        }
    }

    public void NuevoPrograma(Programa programa)
    {
        GameObject btn = Instantiate(botonBarraHerramientas, transform);
        GameObject ventana = Instantiate(programa.ventana, ventanaManager.transform);
        btn.GetComponent<Image>().sprite = programa.icon;
        btn.GetComponent<BotonHerramientas>().ventanaObjetivo = ventana;
    }
}
