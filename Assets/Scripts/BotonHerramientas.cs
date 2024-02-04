using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonHerramientas : MonoBehaviour
{
    [SerializeField] public GameObject ventanaObjetivo;

    public void BotonSeleccionado()
    {
        if (ventanaObjetivo != null)
        {
            if (ventanaObjetivo.activeSelf) { ventanaObjetivo.SetActive(false); }
            else { ventanaObjetivo.SetActive(true); }

        }
    }
    
    
}
