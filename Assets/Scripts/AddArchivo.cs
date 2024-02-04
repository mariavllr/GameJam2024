using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddArchivo : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            print("Mouse clicked");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                gameObject.GetComponentInParent<DescargasManager>().AddArchivo(20, "Default.exe");
                print("Add archivo");
            }
        }
    }
}
