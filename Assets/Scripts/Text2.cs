using UnityEngine;
using System.Collections;

public class AnimateText2 : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;
    public float delay = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; 
        animator.enabled = false; 
    }

    public void StartAnimationWithDelay()
    {
        StartCoroutine(StartAfterDelay());
    }

    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canvasGroup.alpha = 1; 
        animator.enabled = true; 
        animator.Play("CreditosAgradecimentosAnimation"); 
    }
}
