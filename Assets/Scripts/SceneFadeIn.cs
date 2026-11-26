
using UnityEngine;
using System.Collections;

public class SceneFadeIn : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        fadePanel.alpha = 1f;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            fadePanel.alpha = 1f - Mathf.Clamp01(timer / fadeDuration);

            yield return null;
        }

        fadePanel.alpha = 0f;
    }
}
