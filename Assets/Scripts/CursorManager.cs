using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 previousPosition;
    private float previousTime;
    public Vector3 cursorVelocity;

    public float velocityCursorMagnitude;

    void Start()
    {        
        previousPosition = Input.mousePosition;
        previousTime = Time.time;
    }

    void Update()
    {    
        Vector3 currentPosition = Input.mousePosition;
        Vector3 displacement = currentPosition - previousPosition;

        // Calcular el tiempo transcurrido
        float currentTime = Time.time;
        float deltaTime = currentTime - previousTime;

        // Calcular la velocidad del cursor
        cursorVelocity = displacement / deltaTime;

        // Actualizar la posición y el tiempo para el próximo fotograma
        previousPosition = currentPosition;
        previousTime = currentTime;

        // Imprimir la velocidad del cursor
        velocityCursorMagnitude = cursorVelocity.magnitude;
    }
}
