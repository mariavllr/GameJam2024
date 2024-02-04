using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tienda : MonoBehaviour
{
    [SerializeField] GameObject celdaTienda;
    [SerializeField] List<Programa> programas;
    public Dictionary<Button, Programa> diccionario;
    void Start()
    {
        diccionario = new Dictionary<Button, Programa>();
        foreach(Programa programa in programas)
        {
            GameObject celda = Instantiate(celdaTienda, transform);
            Button boton = celda.GetComponent<Button>();

            celda.transform.GetChild(0).GetComponentInChildren<Image>().sprite = programa.icon;
            celda.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = programa.name;
            celda.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = programa.precio.ToString();
            diccionario.Add(boton, programa);
        }
    }
}
