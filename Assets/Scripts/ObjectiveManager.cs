
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TMP_Text objectiveText;

    void Start()
    {
        objectiveText.text = "Objective: Find your keys you left at the park";
    }

    public void KeyCollected()
    {
        objectiveText.text = "Objective: Head back home";
    }
}
