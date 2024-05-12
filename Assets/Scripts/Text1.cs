using UnityEngine;

public class VerticalMoveText : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade do movimento
    public float distance = 500.0f; // Distância vertical que o texto deve percorrer

    private Vector3 startPosition; // Posição inicial
    private Vector3 endPosition; // Posição final
    private bool isMovingUp = true; // Controla se o texto está subindo

    void Start()
    {
        // Define a posição inicial na posição atual do objeto
        startPosition = transform.position;
        // Define a posição final adicionando a distância ao y da posição inicial
        endPosition = new Vector3(startPosition.x, startPosition.y + distance, startPosition.z);
    }

    void Update()
    {
        if (isMovingUp)
        {
            // Move o texto para cima até a posição final
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            // Checa se o texto alcançou a posição final
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                isMovingUp = false; // Desativa o movimento para cima
            }
        }
    }
}

