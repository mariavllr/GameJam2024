using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.yellow;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
