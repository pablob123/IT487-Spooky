using UnityEngine;
using System.Collections;

public class HiddenTrigger : MonoBehaviour
{
    public float moveX = -1.0f;
    public float moveY = 0f;
    public Transform monsterPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(monsterHide());
        }
        
    }

    IEnumerator monsterHide()
    {
        Vector3 newPosition = new Vector3(monsterPosition.position.x + moveX, monsterPosition.position.y + moveY);
        while(Vector3.Distance(monsterPosition.position, newPosition) > 0.01)
        {
            monsterPosition.position = Vector3.MoveTowards(monsterPosition.position, newPosition, 0.03f);
            yield return null;
        }
        monsterPosition.gameObject.SetActive(false);
        gameObject.SetActive(false);
        yield return null;
    }
}
