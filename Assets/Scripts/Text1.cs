using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float speed = 10.0f;
    // As posi��es agora incluem a coordenada z, mantenha-a constante se estiver trabalhando em um ambiente 2D dentro de um Canvas
    public Vector3 startPosition = new Vector3(0, -321, 0); // Ajuste conforme necess�rio para sua cena
    public Vector3 endPosition = new Vector3(0, 640, 0); // Ajuste conforme necess�rio para sua cena
    private bool isMoving = true;

    void Start()
    {
        transform.position = startPosition;
        Debug.Log("Start Position: " + startPosition);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            Debug.Log("Current Position: " + transform.position); // Log para monitorar a posi��o atual

            // Usando uma condi��o mais robusta para verificar se o texto chegou perto da posi��o final
            if (Vector3.Distance(transform.position, endPosition) < 0.1)
            {
                isMoving = false;
                Debug.Log("Reached End Position: " + transform.position);

                AnimateText2 animateText2 = FindObjectOfType<AnimateText2>();
                if (animateText2 != null)
                {
                    animateText2.StartAnimationWithDelay();
                }
                else
                {
                    Debug.LogError("N�o foi poss�vel encontrar o componente AnimateText2 na cena.");
                }
            }
        }
    }
}
