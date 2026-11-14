using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    int key_count = 0;
    public TextMeshProUGUI PopUpText;
    public float displaytime = 2.5f;


    void Start()
    {
        if (PopUpText != null)
        {
            PopUpText.text = "";
        }
    }

    public void AddKey(int num_key)
    {
        key_count += num_key;

        if(PopUpText != null)
        {
            PopUpText.text = "Key added to inventory";
            StartCoroutine(HideMessageTimer());

        }
    }

    private IEnumerator HideMessageTimer()
    {
        yield return new WaitForSeconds(displaytime);
        PopUpText.text = "";
    }

    public int GetKeyCount()
    {
        return key_count;
    }

    public bool UseKey()
    {
        if (key_count > 0)
        {
            key_count--;
            return true;
        }
        return false;
    }

}