using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool Shaking = false;
    public float magnitude = 0.08f;

    void Update()
    {
        if (Shaking)
        {
            Vector2 offset = Random.insideUnitCircle * magnitude;
            transform.localPosition = new Vector3(offset.x, offset.y, 0f);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}