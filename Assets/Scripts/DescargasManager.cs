using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescargasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnArray;

    int archivosIndice = 0;

    [SerializeField] private GameObject[] archivosActuales;


    [SerializeField] GameObject archivoPrefab;

    [SerializeField] GameObject padreArchivos;

    public void AddArchivo()
    {
        if(archivosIndice < archivosActuales.Length)
        {
            GameObject nuevoArchivo = Instantiate(archivoPrefab, spawnArray[archivosIndice].transform.position, Quaternion.identity, padreArchivos.transform);
            nuevoArchivo.GetComponent<Archivo>().spawnFather = spawnArray[archivosIndice];
            archivosActuales[archivosIndice] = nuevoArchivo;
            archivosIndice++;
        }
      
    }
}
