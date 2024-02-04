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
    [SerializeField] FirewallManager firewallManager;
    public GameObject spawnFather;
    public int spawnIndex;
    private Vector2 originPosition;
    float startTime;

    bool returning = false;
    bool throwing = false;
    bool exploding = false;
    public bool quemado = false;
    [SerializeField] GameObject firePrefab;
    [SerializeField] float returnSpeed = 1.0f;

    Rigidbody2D rb;
    Camera mainCamera;

    [SerializeField] GameObject explosionModel;
    [SerializeField] float explosionExpansionSpeed;
    [SerializeField] float explosionDuration;
    [SerializeField] float distanciaSnap;
    

    public Archivo(string nombre, float peso) 
    {
        nombreArchivo = nombre;
        pesoArchivo = peso;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && throwing)
        {
            exploding = true;
            explosionModel.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            rb.velocity = Vector3.zero;
        }
      
    }

    
    private void Awake()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
        descargasManager = GameObject.Find("VentanaDescargas").GetComponent<DescargasManager>();
        firewallManager = GameObject.Find("VentanaFirewall").GetComponent<FirewallManager>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        originPosition = transform.position;


    }

    IEnumerator StopExploding()
    {

        yield return new WaitForSeconds(explosionDuration);
        descargasManager.EliminarArchivo(spawnIndex);
        
            
           

        Destroy(gameObject);

    }

    public void AñadirQuemado()
    {
        quemado = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    void Update()
    {
        if (exploding)
        {
            float maxExplosionRange = pesoArchivo / 10;

            if(explosionModel.transform.localScale.x > maxExplosionRange)
            {
                exploding = false;

                if (quemado)
                {
                    Instantiate(firePrefab, gameObject.transform.position, Quaternion.identity);
                    print("Fogonazo");
                }

                StartCoroutine("StopExploding");
                
               
            }
            else
            {
                Vector3 nuevaEscala = explosionModel.transform.localScale;

                nuevaEscala.x *= pesoArchivo;
                nuevaEscala.y *= pesoArchivo;
                nuevaEscala.z *= pesoArchivo;

                explosionModel.transform.localScale = nuevaEscala;

                //Physics2D.OverlapCircle()
            }

        }

        if (returning)
        {
            transform.position = spawnFather.transform.position;
            returning = false;

            //float journeyLength = Vector3.Distance(originPosition, spawnFather.transform.position);

            //// Calculate the distance covered over time
            //float distCovered = (Time.time - startTime) * returnSpeed;

            //// Calculate the fraction of the journey completed
            //float fracJourney = distCovered / journeyLength;

            //// Move the object towards the target position
            //transform.position = Vector2.Lerp(spawnFather.transform.position, originPosition, fracJourney);

            //// Check if the object has reached the target position
            //if (fracJourney >= 1.0f)
            //{
            //    returning = false;
            //}

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

            if(Vector2.Distance(firewallManager.espacioFirewall.transform.position, transform.position) < distanciaSnap)
            {
                transform.position = firewallManager.espacioFirewall.transform.position;
                firewallManager.AñadirArchivo(gameObject.GetComponent<Archivo>());
                rb.velocity = Vector2.zero;
                print("Añadido");
            }

            else
            {
                startTime = Time.time;
                returning = true;
            }
            
         

            
          
        }

        else
        {
            rb.AddForce(cursorManager.cursorVelocity / 10);
            throwing = true;
        }
    }

    
    
}
