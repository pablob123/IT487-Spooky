using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Multiplayer.PlayMode;

public class changeFloor : MonoBehaviour
{
    [SerializeField]
    private string floor;

    //0 = floor1-floor2     1 = floor2-floor1      2 = floor1-basement      3 = basement-floor1     4 = floor2-attic       5 = attic-floor2
    [SerializeField]
    private int floorChangeVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager.Instance.floorChange(floor, floorChangeVal);
    }
}
