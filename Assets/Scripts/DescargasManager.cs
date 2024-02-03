using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescargasManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnArray;

    int archivosIndice = 0;

    [SerializeField] private GameObject[] archivosActuales;


    [SerializeField] GameObject archivoPrefab;

    public void AddArchivo()
    {
        archivosActuales[archivosIndice] = Instantiate(archivoPrefab, spawnArray[archivosIndice].transform.position, Quaternion.identity);
        archivosIndice++;
    }
}
