using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject celdaTienda;
    [SerializeField] List<Programa> programas;
    void Start()
    {
        foreach(Programa programa in programas)
        {
            GameObject celda = Instantiate(celdaTienda, transform);
            celda.transform.GetChild(0).GetComponentInChildren<Image>().sprite = programa.icon;
            celda.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = programa.name;
        }
    }

    void Update()
    {
        
    }

    void OnCeldaTiendaClick()
    {

    }
}
