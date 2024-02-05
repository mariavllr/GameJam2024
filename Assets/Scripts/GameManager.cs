using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int ram;
    [SerializeField] public int nucleos;
    [SerializeField] public int monedas;
    [SerializeField] public TextMeshProUGUI textMonedas;

    [Header("Ventanas")]
    public int maxVentanasAbiertas;
    public List<GameObject> ventanasAbiertas;
    public Image fadePanel;
    public float fadeSpeed;
    bool muerto;


    [Header("Enemigos")]
    public float vidaEnemigos;
    public float starterVelocity;
    public float currentVelocity;
    public bool canSpawn;
    public float spawnRate;
    public float currentSpawnRate;
    public float cursorDamage;

    [Header("Oleadas")]
    [SerializeField] public TextMeshProUGUI textContador;
    [SerializeField] float tiempoOleada;
    [SerializeField] float tiempoDescanso;
    public float vidaEnemigosActual;
    [SerializeField] float vidaEnemigosInicial;
    
    float tiempoTotal;
    float segundos;
    float minutos;
    Estados estadoActual = Estados.Oleada;


    [Header("Programas")]
    public BarraHerramientas barraHerramientas;
    public List<Programa> programasComprados;

    [Header("Sonido")]
    public AudioSource audioClic;
    public AudioSource audioSoltarClic;
    public AudioSource muerteEnemigo;
    public AudioSource enemigoMeHaceDano;

    enum Estados
    {
        Oleada,
        Descanso
    }

    private void OnEnable()
    {
        Administrador.onRAMValueChanged += CambiarVelocidad;
        Enemy.onDamage += QuitarVida;
    }

    void Start()
    {
        muerto = false;
        currentVelocity = starterVelocity;
        currentSpawnRate = spawnRate;
        segundos = 0;
        canSpawn = true;
        vidaEnemigosActual = vidaEnemigosInicial;
        
    }

    // Update is called once per frame
    void Update()
    {
        maxVentanasAbiertas = ram;
        tiempoTotal += Time.deltaTime;
        minutos = Mathf.FloorToInt(tiempoTotal / 60f);
        segundos = Mathf.FloorToInt(tiempoTotal % 60f);
        textMonedas.text = monedas.ToString();

        GestionarEstados();
        GestionarRAM();

        if (Input.GetMouseButtonDown(0))
        {
            audioClic.Play();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            audioSoltarClic.Play();
        }
    }

    void GestionarRAM()
    {
        if(ventanasAbiertas.Count > maxVentanasAbiertas)
        {
            ventanasAbiertas[0].SetActive(false);
            ventanasAbiertas.RemoveAt(0);
        }
    }

    void GestionarEstados()
    {
        textContador.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        if (estadoActual == Estados.Oleada)
        {
            Oleada();
        }

        else if (estadoActual == Estados.Descanso)
        {
            Descanso();
        }
    }

    void Oleada()
    {
        if (segundos == tiempoOleada + 1)
        {
            tiempoTotal = 0;
            segundos = 0;
            minutos = 0;
            canSpawn = false;
            estadoActual = Estados.Descanso;
        }

    }

    void Descanso()
    {
        if (segundos == tiempoDescanso + 1)
        {
            tiempoTotal = 0;
            segundos = 0;
            minutos = 0;
            canSpawn = true;
            vidaEnemigosActual++;
            estadoActual = Estados.Oleada;
        }     
    }

    void CambiarVelocidad()
    {
        switch (ram)
        {
            case 1:
                currentVelocity = starterVelocity;
                currentSpawnRate = spawnRate;
                break;
            case 2:
                currentVelocity = starterVelocity * 1.5f;
                currentSpawnRate = spawnRate * 0.8f;
                break;
            case 3:
                currentVelocity = starterVelocity * 2f;
                currentSpawnRate = spawnRate* 0.5f;
                break;
            case 4:
                currentVelocity = starterVelocity * 2.5f;
                currentSpawnRate = spawnRate * 0.3f;
                break;
            default:
                break;
        }
    }

    void QuitarVida()
    {
        if(nucleos != 0)
        {
            nucleos--;
        }
        else if(!muerto)
        {
            muerto = true;
            StartCoroutine("Muerte");
        }
        
    }

    IEnumerator Muerte()
    {
        StartCoroutine("FadeIn");
        Time.timeScale -= 0.3f;
        yield return new WaitForSeconds(1f);
        Time.timeScale -= 0.3f;
        yield return new WaitForSeconds(1f);
        Time.timeScale -= 0.3f;
        yield return new WaitForSeconds(1f);
        

    }

    IEnumerator FadeIn()
    {
        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadePanel.color = new Color(100f, 0f, 0f, alpha);
            yield return null;
        }

        SceneManager.LoadScene("Crash");
    }
}
