using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Administrador : MonoBehaviour
{
    Slider slider;
	GameManager gameManager;
	public delegate void OnRAMValueChanged();
	public static event OnRAMValueChanged onRAMValueChanged;
	public void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() ;
		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
	}

	// Invoked when the value of the slider changes.
	public void ValueChangeCheck()
	{
		gameManager.ram = (int)slider.value;
		if (onRAMValueChanged != null)
		{
			onRAMValueChanged();
		}
	}
}
