using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventana : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            print("Mouse clicked");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
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
}
