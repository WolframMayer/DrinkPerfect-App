using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateTemp : MonoBehaviour
{
    public InputField temp;
    public InputField tname;
    public Text output;

    public void CreateTemperature(int level)
    {
        // When added to a button, this function creates a new Temperature, if the Inputfields are not empty
        if (!string.IsNullOrEmpty(tname.text) && !string.IsNullOrEmpty(temp.text)) {
            // Call the function addTemperature in ButtonList and load the next scene
            ButtonList.Instance.addTemperature(tname.text, int.Parse(temp.text));
            SceneManager.LoadScene(level);
        }
        else
        {
            // Inform user that Inputfield is empty
            output.text = "Keine Angabe in Temperatur oder Name";
        }
    }
}
