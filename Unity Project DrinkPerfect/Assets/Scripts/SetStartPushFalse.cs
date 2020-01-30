using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPushFalse : MonoBehaviour
{
    // To be added to finish scene
    // Sets startPush false

    // Start is called before the first frame update
    void Start()
    {
        ButtonList.Instance.SetStartPush(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
