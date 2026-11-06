using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    int key_count = 0;

    void Start()
    {
    }

    public void AddKey(int num_key)
    {
        key_count += num_key;
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