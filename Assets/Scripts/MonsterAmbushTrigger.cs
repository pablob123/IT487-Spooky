
using UnityEngine;

public class MonsterAmbushTrigger : MonoBehaviour
{
    public EnemyAI monster;
    public Transform spawnPoint;

    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || activated)
            return;

        if (monster.isChasing)
            return;

        if (!monster.gameObject.activeInHierarchy)
            return;

        monster.StartAmbush(spawnPoint.position);

        activated = true;
    }
}
