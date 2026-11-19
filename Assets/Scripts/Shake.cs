using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public float duration = 0.5f;
    public float magnitude = 0.2f;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startLocalPos = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            Vector2 offset = Random.insideUnitCircle * magnitude;
            transform.localPosition = startLocalPos + new Vector3(offset.x, offset.y, 0f);

            yield return null;
        }

        transform.localPosition = startLocalPos;
    }
}