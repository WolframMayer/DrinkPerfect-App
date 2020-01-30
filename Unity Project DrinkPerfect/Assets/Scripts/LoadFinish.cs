using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinish : MonoBehaviour
{
    public int level;

    // Update is called once per frame
    void Update()
    {
        // Check once per frame, if startPush is true and temperature is reached
        if (ButtonList.Instance.startPush)
        {
            // If temperature is reached load finish scene
            SceneManager.LoadScene(level);
            ButtonList.Instance.SetIndexTemp(0);

        }
    }
}
