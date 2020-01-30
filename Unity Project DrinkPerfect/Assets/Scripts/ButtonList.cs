using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonList : MonoBehaviour
{
    // This Datamanager will be kept alive and saved through all scene changes
    public static ButtonList Instance;
    public List<Temperature> buttons = new List<Temperature>();
    private static int IndexTemp = 0;
    public bool startPush = false;
    private void Awake()
    {   
        // Keep this object alive through all scenes
        DontDestroyOnLoad(gameObject);

        // Save object in Instance
        Instance = this;
    }

    public void addTemperature(string name, int temp)
    {
        // create a new Temperature and add it to the list
        Temperature newTemp = new Temperature(name, temp);
        buttons.Add(newTemp);
    }

    public void Setup()
    {
        // Load the default temperatures into the list
        Temperature tee = new Temperature("Tee", 60);
        Temperature wine = new Temperature("Wein", 18);
        Temperature beer = new Temperature("Bier", 7);

        buttons.Add(tee);
        buttons.Add(wine);
        buttons.Add(beer);
    }

    public void SetIndexTemp(int index)
    {
        IndexTemp = index;
    }

    public int GetIndexTemp()
    {
        return IndexTemp;
    }

    public void SetStartPush(bool value)
    {
        startPush = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
