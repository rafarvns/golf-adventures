using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarAnimator : MonoBehaviour
{
    public Image[] stars; 
    public float animationDuration = 1.0f;
    public Vector2 minScale = new Vector2(0.5f, 0.5f); 
    public Vector2 maxScale = new Vector2(1.5f, 1.5f); 

    void Start()
    {
        
        foreach (Image star in stars)
        {
            float randomDelay = Random.Range(0f, animationDuration);
            StartCoroutine(AnimateStar(star, randomDelay));
        }
    }

    IEnumerator AnimateStar(Image star, float delay)
    {
        
        yield return new WaitForSeconds(delay);

        while (true)
        {
            
            yield return ScaleStar(star, minScale, maxScale);
           
            yield return ScaleStar(star, maxScale, minScale);
        }
    }

    IEnumerator ScaleStar(Image star, Vector2 fromScale, Vector2 toScale)
    {
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            star.rectTransform.localScale = Vector2.Lerp(fromScale, toScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        star.rectTransform.localScale = toScale;
    }
}
