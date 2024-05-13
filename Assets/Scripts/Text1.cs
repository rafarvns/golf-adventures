using TMPro;
using UnityEngine;

public class VerticalMoveText : MonoBehaviour
{
    public float speed = 5f; 

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMovingUp = true;

    void Start()
    {
        startPosition = transform.position;
        // Calcula o tamanho do texto em pixels
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();

        // Calcula o tamanho do texto em relação à tela
        float textHeight = 100 + textMeshPro.preferredHeight / 4;

        // Obtém o tamanho da tela em pixels
        float screenHeight = Screen.height;

        // Calcula o endPosition somando o tamanho da tela ao tamanho do texto
        endPosition = new Vector3(startPosition.x, screenHeight + textHeight, startPosition.z);
    }

    void Update()
    {
        if (isMovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                isMovingUp = false;
                ActivateText2(); 
                gameObject.SetActive(false);
            }
        }
    }

    void ActivateText2()
    {
        GameObject text2 = GameObject.Find("Agradecimentos");
        if (text2 != null)
        {
            AnimateText2 animateText2 = text2.GetComponent<AnimateText2>();
            if (animateText2 != null)
            {
                animateText2.StartAnimationWithDelay();
            }
        }
    }
}
