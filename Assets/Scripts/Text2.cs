using UnityEngine;
using System.Collections;

public class AnimateText2 : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
    public float delay = 2f; // Delay em segundos

    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; // Inicia invisível
        animator.enabled = false; // Desativa o Animator inicialmente
    }

    public void StartAnimationWithDelay()
    {
        StartCoroutine(StartAfterDelay());
    }

    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canvasGroup.alpha = 1; // Torna o texto visível
        animator.enabled = true; // Ativa o Animator
        animator.Play("CreditosAgradecimentosAnimation"); // Substitua pelo nome correto da animação
    }
}
