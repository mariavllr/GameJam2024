using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int ram;
    [SerializeField] public int nucleos;

    [Header("Enemigos")]
    public float starterVelocity;
    public float currentVelocity;
    public float spawnRate;
    public float currentSpawnRate;
    public float cursorDamage;

    private void OnEnable()
    {
        Administrador.onRAMValueChanged += CambiarVelocidad;
        Enemy.onDamage += QuitarVida;
    }

    void Start()
    {
        currentVelocity = starterVelocity;
        currentSpawnRate = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        
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
