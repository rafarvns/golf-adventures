using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    public float velocidade = 20f; 
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
      
        rectTransform.anchoredPosition += Vector2.up * velocidade * Time.deltaTime;
    }
}
