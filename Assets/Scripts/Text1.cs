using UnityEngine;

public class VerticalMoveText : MonoBehaviour
{
    public float speed = 5f; 
    public float distance = 1000f; 

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
                ActivateText2(); 
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
