using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FirewallManager : MonoBehaviour
{
    public float valorDeQuemado = 0f;
    public GameObject espacioFirewall;

    [SerializeField] float velocidadQuemado = 0.05f;
    [SerializeField] GameObject sliderFirewall;
    [SerializeField] Slider slider;

    [SerializeField] bool quemando = false;
    [SerializeField] Archivo archivoActual;

    private void Awake()
    {
        slider = sliderFirewall.GetComponent<Slider>();
    }
    public void AñadirArchivo(Archivo archivo)
    {
        slider.value = 0f;
        archivoActual = archivo;
        quemando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (quemando)
        {
            slider.value += velocidadQuemado;

            if(slider.value >= 1)
            {
                print(archivoActual.ToString());
                archivoActual.AñadirQuemado();
                quemando = false;

            }
        }
    }
}
