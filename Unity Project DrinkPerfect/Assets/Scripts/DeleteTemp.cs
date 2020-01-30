using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeleteTemp : MonoBehaviour
{
    private List<GameObject> list;

    public void SetList(List<GameObject> list)
    {
        this.list = list;
    }

    public List<GameObject> GetList()
    {
        return list;
    }
    public void DeleteTemperature(int level)
    {
        // Creat list of index
        List<int> index = new List<int>();

        // Save number of Toggles
        int max = list.Count;
        for(int i = 0; i < max; i++)
        {
            if (list[i].GetComponent<Toggle>().isOn)
            {
                // Get the IndexToggle in list and add it's index to list of index
                index.Add(list[i].GetComponent<IndexToggle>().GetIndex());
            }
        }
        int n = 0;
        for(int i = 0; i < index.Count;i++)
        {
            // Delete all Temperatures in ButtonList list with an additional index in index list
            ButtonList.Instance.buttons.RemoveAt(index[i] - n);
            n++;
        }
        SceneManager.LoadScene(level);
    }
}
