using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Archivo : MonoBehaviour {

    public Sprite imagenArchivo;
    public string nombreArchivo;
    public float pesoArchivo;

    private bool isDragging = false;
    private Vector3 offset;
    [SerializeField] CursorManager cursorManager;
    [SerializeField] float minCursorSpeed;
    [SerializeField] DescargasManager descargasManager;
    public GameObject spawnFather;
    public int spawnIndex;
    private Vector2 originPosition;
    float startTime;

    bool returning = false;
    bool throwing = false;
    [SerializeField] float returnSpeed = 1.0f;

    Rigidbody2D rb;
    Camera mainCamera;

    public Archivo(string nombre, float peso) 
    {
        nombreArchivo = nombre;
        pesoArchivo = peso;
    }
    private void Awake()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
        descargasManager = GameObject.Find("VentanaDescargas").GetComponent<DescargasManager>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        originPosition = transform.position;


    }

    void Update()
    {

        if (returning)
        {
            float journeyLength = Vector3.Distance(originPosition, spawnFather.transform.position);

            // Calculate the distance covered over time
            float distCovered = (Time.time - startTime) * returnSpeed;

            // Calculate the fraction of the journey completed
            float fracJourney = distCovered / journeyLength;

            // Move the object towards the target position
            transform.position = Vector2.Lerp(originPosition, spawnFather.transform.position, fracJourney);

            // Check if the object has reached the target position
            if (fracJourney >= 1.0f)
            {
                returning = false;
            }

        }

        if (IsOutOfScreen())
        {
            Destroy(gameObject);
            descargasManager.EliminarArchivo(spawnIndex);
            print("Archivo eliminado");
            
        }

        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            //print("Mouse clicked");



            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {


                if (hit.collider.gameObject.CompareTag("Descargas"))
                {
                    print("Descargas");
                    for (int child = 0; child < transform.childCount; child++)
                    {
                        transform.GetChild(child).GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Archivos";
                        print("Sprite modificado.");
                    }


                    GameObject ventanaArchivos = GameObject.Find("Archivos");

                    if (ventanaArchivos.transform.childCount > 0)
                    {
                        for (int child = 0; child < ventanaArchivos.transform.childCount; child++)
                        {
                            ventanaArchivos.transform.GetChild(child).GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Archivos";
                            print("Sprite modificado.");
                        }
                    }



                }
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Left mouse button up
        {
            isDragging = false;
            ThrowOrReturn();
        }

        if (isDragging)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);
        }
    }

    bool IsOutOfScreen()
    {
        // Obtener la posición del objeto en coordenadas de la pantalla
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        // Verificar si la posición está fuera de la pantalla
        if (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height)
        {
            return true;
        }

        return false;
    }

    private void ThrowOrReturn()
    {
        if(cursorManager.velocityCursorMagnitude < minCursorSpeed)
        {
            
            startTime = Time.time;
            returning = true;

            
          
        }

        else
        {
            rb.AddForce(cursorManager.cursorVelocity / 10);
           
        }
    }

    
    
}
