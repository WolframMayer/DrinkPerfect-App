using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ToggleTemp : MonoBehaviour
{
    // Load list of Toggle into container of vertical layout group
    private List<Temperature> list;
    public GameObject prefab;       // Toggle prefab
    public GameObject delTemp;      // Delete prefab
    public GameObject backButton;   // Back prefab
    public GameObject parent;       // Container of vertical layout group
    private List<GameObject> ToggleList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        list = ButtonList.Instance.buttons;
        LoadToggle();
    }
    public void LoadToggle()
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject newToggle = (GameObject)Instantiate(prefab);
            newToggle.transform.SetParent(parent.transform, false);
            newToggle.transform.SetAsLastSibling();
            newToggle.GetComponent<IndexToggle>().SetIndex(i, list[i].TempName);

            ToggleList.Add(newToggle);
        }
        GameObject delPrefab = Instantiate(delTemp) as GameObject;
        delPrefab.transform.SetParent(parent.transform, false);
        delPrefab.transform.SetAsLastSibling();
        delPrefab.GetComponent<DeleteTemp>().SetList(ToggleList);

        GameObject backPrefab = Instantiate(backButton) as GameObject;
        backPrefab.transform.SetParent(parent.transform, false);
        backPrefab.transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
