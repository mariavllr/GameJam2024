using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ventana : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            //print("Mouse clicked");


            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            

            if (hit.collider != null && hit.collider.gameObject == gameObject && hit.collider.gameObject.layer == 6)
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

                    if(ventanaArchivos.transform.childCount > 0)
                    {
                        for (int child = 0; child < ventanaArchivos.transform.childCount; child++)
                        {
                            ventanaArchivos.transform.GetChild(child).GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Archivos";
                            print("Sprite modificado.");
                        }
                    }
                    


                }

                else
                {
                    hit.collider.GetComponentInChildren<Canvas>().sortingOrder = 100;
                }
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.GetComponentInParent<VentanaManager>().CambioDeUltimaVentana(gameObject.GetComponent<Ventana>());
            }
        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button up
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDragging)
        {
            isDragging = false;
        }
    }
}
