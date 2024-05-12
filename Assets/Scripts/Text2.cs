using UnityEngine;
using System.Collections;

public class AnimateText2 : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
    public float delay = 2.0f;  // Delay em segundos antes de iniciar a anima��o

    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;  // Assegura que o texto comece invis�vel
        animator.enabled = false;
    }

    public void StartAnimationWithDelay()
    {
        StartCoroutine(StartAfterDelay());
    }

    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canvasGroup.alpha = 1;  // Torna o texto vis�vel
        animator.enabled = true;
        animator.Play("CreditosAgradecimentosAnimation");
    }
}
