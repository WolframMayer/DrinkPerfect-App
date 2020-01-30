using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureConst : MonoBehaviour
{
    // Temperature constant for non permanent and permanent temperatures
    private static int tempValue = 0;
    public InputField temp;
    public InputField tname;

    public void SetTempValue(){
        if (!string.IsNullOrEmpty(tname.text) && !string.IsNullOrEmpty(temp.text))
        {
            tempValue = gameObject.GetComponent<TemperatureButton>().temperature;
            ButtonList.Instance.SetIndexTemp(tempValue);
            Debug.Log(tempValue);
        }
     }

     public void SetNonPermanentValue(Text value)
    {
        if (!string.IsNullOrEmpty(temp.text))
        {
            tempValue = int.Parse(value.text);
            ButtonList.Instance.SetIndexTemp(tempValue);
            Debug.Log(tempValue);
        }
    }

     public int GetTempValue(){
        return tempValue;
     }
}
