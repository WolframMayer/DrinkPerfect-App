using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization.Json;

public class SaveLoad : MonoBehaviour
{
    // Load the additional temperature to the list or save them in a file
    public static List<Temperature> savedGames = new List<Temperature>();
    private static bool AppStart = true;
    private static string json;
    private static string getJson = null;

    public void Save()
    {
        // Save all additional temperatures in list of temperatures from ButtonList in savedGames
        savedGames.Clear();
        for (int i = 3; i < ButtonList.Instance.buttons.Count; i++)
        {
            savedGames.Add(ButtonList.Instance.buttons[i]);
        }

        //  Create new WrappingClass and save savedGames in it
        WrappingClass variable = new WrappingClass();
        variable.Inventory = savedGames;
        
        // Create JSON out of WrappingClass and save it in persistent data path of device
        json = JsonUtility.ToJson(variable);
        File.WriteAllText(Application.persistentDataPath + "/savedTemp.json", json);
    }

    public void Load()
    {
        savedGames.Clear();
        if (File.Exists(Application.persistentDataPath + "/savedTemp.json"))
        {
            // Get JSON from saved file and receive the WrappingClass from it
            getJson = File.ReadAllText(Application.persistentDataPath + "/savedTemp.json");
            WrappingClass variable = JsonUtility.FromJson<WrappingClass>(getJson);
            
            // Save list of WrappingClass in savedGames
            savedGames = variable.Inventory;
            ButtonList.Instance.Setup();

            // Add the temperatures in savedGames in temperature list of ButtonList
            for (int i = 0; i < savedGames.Count; i++)
            {
                ButtonList.Instance.buttons.Add(savedGames[i]);
            }        
        } else {
            ButtonList.Instance.Setup();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // If the App just startet, load the additional temperatures
        if (AppStart)
        {
            Load();
            AppStart = false;
        } else
        {
            Save();
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

