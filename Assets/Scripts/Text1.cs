using UnityEngine;

public class VerticalMoveText : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento
    public float distance = 1000f; // Distância vertical que o texto deve percorrer

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMovingUp = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + distance, startPosition.z);
    }

    void Update()
    {
        if (isMovingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                isMovingUp = false;
                ActivateText2(); // Chamada para ativar o Texto 2
            }
        }
    }

    void ActivateText2()
    {
        GameObject text2 = GameObject.Find("Agradecimentos"); // Substitua pelo nome correto do objeto Texto 2
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
