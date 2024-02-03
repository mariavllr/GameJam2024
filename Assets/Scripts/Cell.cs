using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool hayArchivo;
    public Vector2 posicion;
    public Archivo contenidoArchivo;

    public Cell()
    {
        hayArchivo = false;
        posicion = Vector2.zero;
        contenidoArchivo = null;
    }
}
