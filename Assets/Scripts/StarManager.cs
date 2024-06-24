using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public List<Image> stars;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public float animationDuration = 1f;

    void Start()
    {
        StartCoroutine(AnimateStars());
    }

    IEnumerator AnimateStars()
    {
        while (true)
        {
            foreach (Image star in stars)
            {
                float randomDelay = Random.Range(0f, 0.5f);
                StartCoroutine(AnimateStar(star, randomDelay));
            }
            yield return new WaitForSeconds(animationDuration);
        }
    }

    IEnumerator AnimateStar(Image star, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 originalScale = star.transform.localScale;
        Vector3 targetScale = originalScale * Random.Range(minScale, maxScale);

        float time = 0f;
        while (time < animationDuration)
        {
            star.transform.localScale = Vector3.Lerp(originalScale, targetScale, time / animationDuration);
            time += Time.deltaTime;
            yield return null;
        }

        star.transform.localScale = originalScale;
    }
}
