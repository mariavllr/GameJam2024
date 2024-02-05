using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonTienda : MonoBehaviour
{
    Tienda tienda;
    GameManager gameManager;
    Button boton;
    [SerializeField] AudioSource audioComprar;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tienda = GameObject.FindGameObjectWithTag("Tienda").GetComponent<Tienda>();
        boton = GetComponent<Button>();
    }

    public void onClick()
    {
        Programa programa = tienda.diccionario[boton];
        if (gameManager.programasComprados.Contains(programa))
        {
            print("ya estaba comprado!");
        }
        else
        {
            if(gameManager.monedas >= programa.precio)
            {
                gameManager.monedas = gameManager.monedas - programa.precio;
                gameManager.programasComprados.Add(programa);
                gameManager.barraHerramientas.NuevoPrograma(programa);
                boton.interactable = false;
                boton.gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
                audioComprar.Play();
            }
        }
    }
}
