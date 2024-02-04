using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaManager : MonoBehaviour
{
    [SerializeField] Ventana ultimaVentana;    

    public void CambioDeUltimaVentana(Ventana nuevaVentana)
    {
        if(ultimaVentana != null) { 
            ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

            if (ultimaVentana.gameObject.CompareTag("Descargas") && ultimaVentana != nuevaVentana)
            {

                GameObject ventanaDescargas = GameObject.Find("VentanaDescargas");
                for (int child = 0; child < ventanaDescargas.transform.childCount; child++)
                {

                    ventanaDescargas.transform.GetChild(child).GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Default";
                    print("Sprite modificado.");

                    
                }

                GameObject ventanaArchivos = GameObject.Find("Archivos"); 

                for (int child = 0; child < ventanaArchivos.transform.childCount; child++)
                {
                    
                    ventanaArchivos.transform.GetChild(child).GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Default";
                    //ventanaArchivos.transform.GetChild(child).GetComponent<Archivo>().spawnFather = ventanaDescargas.GetComponent<DescargasManager>().spawnArray[child].gameObject;
                    print("Sprite modificado.");
                }





            }
        }
       
        ultimaVentana = nuevaVentana;
        ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
        ultimaVentana.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Ventana";


    }
}
