using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickCheck : MonoBehaviour
{
    // To be added to the temperature Button, if clicked, the scene with the mqtt-communication is loaded
    public void LoadCheckScene(int level)
    {
        SceneManager.LoadScene(level);
        ButtonList.Instance.SetIndexTemp(this.GetComponent<TemperatureButton>().temperature);
    }
}
