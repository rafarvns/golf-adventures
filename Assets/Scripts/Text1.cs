using UnityEngine;

public class VerticalMoveText : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade do movimento
    public float distance = 500.0f; // Dist�ncia vertical que o texto deve percorrer

    private Vector3 startPosition; // Posi��o inicial
    private Vector3 endPosition; // Posi��o final
    private bool isMovingUp = true; // Controla se o texto est� subindo

    void Start()
    {
        // Define a posi��o inicial na posi��o atual do objeto
        startPosition = transform.position;
        // Define a posi��o final adicionando a dist�ncia ao y da posi��o inicial
        endPosition = new Vector3(startPosition.x, startPosition.y + distance, startPosition.z);
    }

    void Update()
    {
        if (isMovingUp)
        {
            // Move o texto para cima at� a posi��o final
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            // Checa se o texto alcan�ou a posi��o final
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                isMovingUp = false; // Desativa o movimento para cima
            }
        }
    }
}

