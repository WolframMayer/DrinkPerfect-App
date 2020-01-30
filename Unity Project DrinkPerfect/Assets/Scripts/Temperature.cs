using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Must be serializable to be saved in a file
[System.Serializable]
public class Temperature
{
    // Define temperature attributes
    public string TempName = "ButtonName";
    public int TempValue;

    public Temperature(string name, int temp)
    {
        TempName = name;
        TempValue = temp;
    }
}
