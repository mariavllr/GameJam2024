using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescargasManager : MonoBehaviour
{
    [SerializeField] public GameObject[] spawnArray;

    private Cell[] celdas;

    int archivosIndice = 0;

    //[SerializeField] private GameObject[] archivosActuales;


    [SerializeField] GameObject archivoPrefab;

    [SerializeField] GameObject padreArchivos;

    private void Awake()
    {
        celdas = new Cell[spawnArray.Length];
        print(celdas.Length);
        for(int c = 0; c < celdas.Length; c++)
        {
            celdas[c] = new Cell();  
            celdas[c].hayArchivo = false;
            celdas[c].posicion = spawnArray[c].transform.position;
            celdas[c].contenidoArchivo = null;
        }
        
    }
    public void AddArchivo(int peso, string nombre)
    {
        if(archivosIndice < celdas.Length)
        {
            GameObject nuevoArchivo = Instantiate(archivoPrefab, spawnArray[archivosIndice].transform.position, Quaternion.identity, padreArchivos.transform);
            nuevoArchivo.GetComponent<Archivo>().spawnFather = spawnArray[archivosIndice];
            nuevoArchivo.GetComponent<Archivo>().spawnIndex = archivosIndice;
            celdas[archivosIndice].hayArchivo = true;
            celdas[archivosIndice].contenidoArchivo = nuevoArchivo.GetComponent<Archivo>();
            celdas[archivosIndice].posicion = spawnArray[archivosIndice].transform.position;


            archivosIndice++;
        }
      
    }

    public void EliminarArchivo(int x)
    {
        celdas[x].contenidoArchivo = null;
        celdas[x].hayArchivo = false;

        for(int index = x + 1; index < celdas.Length + 1; index++)
        {
            if (celdas[index].hayArchivo)
            {

                int anterior = index - 1;
                
                celdas[anterior].contenidoArchivo = celdas[index].contenidoArchivo;
                celdas[anterior].contenidoArchivo.transform.position = spawnArray[anterior].transform.position;
                celdas[anterior].contenidoArchivo.spawnFather = spawnArray[anterior];
                celdas[anterior].contenidoArchivo.spawnIndex = anterior;
                celdas[anterior].hayArchivo = true;
                print(celdas[anterior].contenidoArchivo.transform.position);
                celdas[index].hayArchivo = false;
                celdas[index].contenidoArchivo = null;
            }
            else
            {
                print("Break");
                break;
            }
        
        
        }

        archivosIndice--;

    }
}
