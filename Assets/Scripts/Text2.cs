using UnityEngine;
using System.Collections;

public class AnimateText2 : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;

    void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; 
        animator.enabled = false; 
    }

    public void StartAnimationWithDelay()
    {
        canvasGroup.alpha = 1; 
        animator.enabled = true; 
        animator.Play("CreditosAgradecimentosAnimation"); 
    }

}
