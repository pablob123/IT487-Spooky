using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void floorChange(string floor, int floorVal)
    {

            Vector3 position;

            if (floorVal == 0)
            {
                position = new Vector3(9.47f, -1.73f, 0f);
                StartCoroutine(floorChange(floor, position));
            }
            else if (floorVal == 1)
            {
                position = new Vector3(28.26f, 11.05f, 0f);
                StartCoroutine(floorChange(floor, position));
            }
            else if (floorVal == 2)
            {
                position = new Vector3(8.414998f, 6.985001f, 0f);
                StartCoroutine(floorChange(floor,position));
            }
            else if (floorVal == 3)
            {
                position = new Vector3(30.42f, 9.59f, 0f);
                StartCoroutine(floorChange(floor, position));
            }
    }
    private IEnumerator floorChange(string floor, Vector3 position)
    {
        AsyncOperation changefloor = SceneManager.LoadSceneAsync(floor);

        while (!changefloor.isDone)
        {
            yield return null;
        }
        Debug.Log("e");
        GameObject currPlayer = GameObject.FindGameObjectWithTag("Player");

        currPlayer.transform.position = position;


        yield return null;
    }
}
