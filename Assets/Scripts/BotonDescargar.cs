using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDescargar : MonoBehaviour
{
    [SerializeField] TorrentManager torrentManager;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !torrentManager.descargando) // Left mouse button down
        {           

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                torrentManager.BotonDescargandoPulsado();

            }

        }
    }

   

}
