using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPrograma", menuName = "ScriptableObjects/Programa", order = 1)]
public class Programa : ScriptableObject
{
    public Sprite icon;
    public string nombre;
    public GameObject ventana;
    public int precio;
}
