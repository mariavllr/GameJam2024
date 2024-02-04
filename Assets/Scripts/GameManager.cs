using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int ram;
    [SerializeField] public int nucleos;
    [SerializeField] public int monedas;
    [SerializeField] public TextMeshProUGUI textMonedas;


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
        currentVelocity = starterVelocity;
        currentSpawnRate = spawnRate;
        segundos = 0;
        canSpawn = true;
        vidaEnemigosActual = vidaEnemigosInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTotal += Time.deltaTime;
        minutos = Mathf.FloorToInt(tiempoTotal / 60f);
        segundos = Mathf.FloorToInt(tiempoTotal % 60f);
        textMonedas.text = monedas.ToString();
        GestionarEstados();
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
                currentVelocity = starterVelocity * 2f;
                currentSpawnRate = spawnRate * 0.5f;
                break;
            case 3:
                currentVelocity = starterVelocity * 2.5f;
                currentSpawnRate = spawnRate* 0.15f;
                break;
            case 4:
                currentVelocity = starterVelocity * 3.5f;
                currentSpawnRate = spawnRate * 0.05f;
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
        else
        {
            Debug.Log("muerto");
        }
        
    }
}
