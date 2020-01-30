using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnChlickEinstellung : MonoBehaviour
{
    // Set new temperature without saving it
    public InputField field;
    public Text output;
    public void LoadSceneIf(int level)
    {
        if (!string.IsNullOrEmpty(field.text))
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            output.text = "No Name or Temperature inserted";
        }
    }
}
