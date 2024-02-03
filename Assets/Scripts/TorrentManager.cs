using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TorrentManager : MonoBehaviour
{
    [SerializeField] float velocidadInternet = 0.001f;
    [SerializeField] GameObject barraProgreso;

    DescargasManager descargasManager;

    public bool descargando = false;
    int nivelTorrent = 1;
    float minimoPeso = 20;
    float maximoPeso = 3000;
    string nombrePorDefecto = "CharlieYLaFabricaDeChocolate.mp4";
    

    enum Tipo
    {
        mp4, exe, pdf, mp3
    }

    //Lista de imagenes y de nombres

    private void Update()
    {
        if (descargando && gameObject.activeSelf)
        {
            Vector3 currentScale = barraProgreso.transform.localScale;

            currentScale.x += velocidadInternet;

            barraProgreso.transform.localScale = currentScale;

            if(barraProgreso.transform.localScale.x >= 1)
            {
                descargando = false;
                descargasManager.AddArchivo();
                barraProgreso.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }

    private void Awake()
    {
        descargasManager = FindObjectOfType<DescargasManager>();
        barraProgreso.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void BotonDescargandoPulsado()
    {
        descargando = true;
        print("Empieza la descarga");
        GenerarArchivoNuevo();
        
    }

    private void GenerarArchivoNuevo()
    {

        Vector3 currentScale = barraProgreso.transform.localScale;

        currentScale.x = 0;
        barraProgreso.GetComponent<SpriteRenderer>().color = Color.blue;
        barraProgreso.transform.localScale = currentScale;

        string nuevoNombre = nombrePorDefecto;
        float nuevoPeso = UnityEngine.Random.Range(minimoPeso, maximoPeso);


        
    }
}
