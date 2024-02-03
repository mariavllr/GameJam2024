using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]  GameObject enemyPrefab;
    [SerializeField] GameObject container;
    [SerializeField] float spawnRate;
    private float limiteI, limiteD;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        limiteD = renderer.bounds.size.x;
        limiteI = renderer.bounds.size.y;
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float xAleatorio = Random.Range(transform.position.x - limiteD / 2f, transform.position.x + limiteD / 2f);
        float y = transform.position.y + limiteI / 2f;
        Vector3 posicionAleatoria = new Vector3(xAleatorio, y, 0f);

        Instantiate(enemyPrefab, posicionAleatoria, Quaternion.identity, container.transform);
    }
}
