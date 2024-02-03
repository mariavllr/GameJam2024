using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    GameManager gameManager;

    public delegate void OnDamage();
    public static event OnDamage onDamage;

    [SerializeField] float vida;
    [SerializeField] GameObject canvasVida;
    [SerializeField] float tiempoNumeroVisible;
    [SerializeField] float cooldown;
    private bool canTakeDamage;
    private float numero;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * (gameManager.currentVelocity * Time.deltaTime));
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //El enemigo me hace da�o a mi
        if (onDamage != null)
        {
            onDamage();
        }
        Die();
    }

    void OnMouseOver()
    {
        TakeDamage(gameManager.cursorDamage); 
    }

    //Le hago da�o al enemigo
    void TakeDamage(float dmg)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            numero = dmg;
            StartCoroutine("MostrarNumero");
            StartCoroutine("TakeDamageCoroutine");
        }
    }

    IEnumerator TakeDamageCoroutine()
    {
        vida -= numero;
        if (vida <= 0)
        {
            Die();
        }

        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }

    IEnumerator MostrarNumero()
    {
        canvasVida.SetActive(true);
        canvasVida.GetComponentInChildren<TextMeshProUGUI>().text = numero.ToString();
        yield return new WaitForSeconds(tiempoNumeroVisible);
        canvasVida.SetActive(false);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
