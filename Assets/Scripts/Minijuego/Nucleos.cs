using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nucleos : MonoBehaviour
{
    [SerializeField] Sprite spriteActivo;
    [SerializeField] Sprite spriteInactivo;
    private void OnEnable()
    {
        Enemy.onDamage += QuitarNucleo;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuitarNucleo()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject nucleo = transform.GetChild(i).gameObject;

            if (nucleo.GetComponent<Image>().sprite == spriteActivo)
            {
                nucleo.GetComponent<Image>().sprite = spriteInactivo; 
                break;
            }
        }
    }
}
