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
    public GameObject spawnFather;

    bool returning = false;
    [SerializeField] float returnSpeed = 1.0f;

    private void Awake()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();

    }

    void Update()
    {
        if (returning)
        {
           
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

    private void ThrowOrReturn()
    {
        if(cursorManager.velocityCursorMagnitude < minCursorSpeed)
        {
            StartCoroutine("ReturnToSpawn");

            
          
        }

        else
        {
            transform.Translate(cursorManager.cursorVelocity.normalized * cursorManager.velocityCursorMagnitude / 10 );
        }
    }

    
    IEnumerator ReturnToSpawn()
    {
        //Vector3 startPosition = transform.position;
        // Obtener la posición final
        Vector3 endPosition = spawnFather.transform.position;
        // Calcular la distancia entre las posiciones inicial y final
        //float distance = Vector3.Distance(startPosition, endPosition);

        // Mientras no se haya llegado a la posición final
        while (transform.position != endPosition)
        {
            // Calcular la nueva posición
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

            // Esperar hasta el siguiente frame
            yield return null;
        }

    }
}
