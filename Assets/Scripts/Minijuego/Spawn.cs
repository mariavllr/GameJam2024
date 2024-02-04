using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]  GameObject enemyPrefab;
    [SerializeField] GameObject container;
    GameManager gM;
    private float limiteI, limiteD;
    float timer = 0;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        limiteD = renderer.bounds.size.x;
        limiteI = renderer.bounds.size.y;
        //InvokeRepeating("SpawnEnemy", 0f, gM.spawnRate);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= gM.currentSpawnRate && gM.canSpawn)
        {
            StartCoroutine("SpawnEnemy");
            timer = 0;
        }
        
    }

    void SpawnEnemy()
    {
        float xAleatorio = Random.Range(transform.position.x - limiteD / 2f, transform.position.x + limiteD / 2f);
        float y = transform.position.y + limiteI / 2f;
        Vector3 posicionAleatoria = new Vector3(xAleatorio, y, 0f);

        Instantiate(enemyPrefab, posicionAleatoria, Quaternion.identity, container.transform);
    }
}
