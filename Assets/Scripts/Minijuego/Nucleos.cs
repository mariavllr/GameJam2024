using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleos : MonoBehaviour
{
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
        if(transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
