using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexToggle : MonoBehaviour
{
    // IndexToggle is a component to add to a Toggle object for the deletion of temperatures
    private int index;
    public Text Name;
    
    public void SetIndex(int index, string Name)
    {
        this.index = index;
        this.Name.text = Name;
    }
    
    public int GetIndex()
    {
        return index;
    }
}
