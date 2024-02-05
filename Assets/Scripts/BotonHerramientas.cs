using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonHerramientas : MonoBehaviour
{
    [SerializeField] public GameObject ventanaObjetivo;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void BotonSeleccionado()
    {
        if (ventanaObjetivo != null)
        {
            if (ventanaObjetivo.activeSelf)
            {
                ventanaObjetivo.SetActive(false);
                gameManager.ventanasAbiertas.Remove(ventanaObjetivo);
            }
            else if(gameManager.ventanasAbiertas.Count < gameManager.maxVentanasAbiertas)
            {
                ventanaObjetivo.SetActive(true);
                gameManager.ventanasAbiertas.Add(ventanaObjetivo);
            }
        }
    }
    
    
}
