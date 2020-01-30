using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButtons : MonoBehaviour
{
    // Load Buttons onto the vertical layout group container according to list of temperatures
    public List<Temperature> list;
    public GameObject prefab;       // Prefab of the loaded Button
    public GameObject newTemp;      // Prefab of Create button
    public GameObject delTemp;      // Prefab of Delete button
    public GameObject parent;       // Container of the vertical layout group

    // Start is called before the first frame update
    void Start()
    {
        list = ButtonList.Instance.buttons;
        ReloadButtons();
    }

    public void ReloadButtons()
    {
        //List<GameObject> Button = new List<GameObject>();

        // Load the temperature buttons
        for (int i = 0; i < list.Count; i++)
        {
            GameObject newButton = (GameObject) Instantiate(prefab);
            newButton.transform.SetParent(parent.transform, false);
            newButton.transform.SetAsLastSibling();
            newButton.GetComponent<TemperatureButton>().buttonText.text = list[i].TempName;
            newButton.GetComponent<TemperatureButton>().temperature = list[i].TempValue;
   
            //Button.Add(newButton);
        }

        // Load Create and Delete button
        GameObject tempPrefab = (GameObject) Instantiate(newTemp);
        tempPrefab.transform.SetParent(parent.transform, false);
        tempPrefab.transform.SetAsLastSibling();

        GameObject tempPrefab2 = (GameObject) Instantiate(delTemp);
        tempPrefab2.transform.SetParent(parent.transform, false);
        tempPrefab2.transform.SetAsLastSibling();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
