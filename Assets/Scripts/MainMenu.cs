using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeDuration = 2f;

    public void StartGame()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fadePanel.blocksRaycasts = true;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            fadePanel.alpha = Mathf.Clamp01(timer / fadeDuration);

            yield return null;
        }

        fadePanel.alpha = 1f;

        SceneManager.LoadScene("StartingScene");
    }
}
