using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaManager : MonoBehaviour
{
    [SerializeField] Ventana ultimaVentana;    

    public void CambioDeUltimaVentana(Ventana nuevaVentana)
    {
        if(ultimaVentana != null) { ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1; }
       
        ultimaVentana = nuevaVentana;
        ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;

    }
}
