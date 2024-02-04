using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(300);
            StartCoroutine("Destruction");
        }
    }


    IEnumerator Destruction()
    {

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemigo"))
    //    {
    //        print("Detecta enemigo");
    //        collision.gameObject.GetComponent<Enemy>().TakeDamage(300);
    //    }
    //}
}
