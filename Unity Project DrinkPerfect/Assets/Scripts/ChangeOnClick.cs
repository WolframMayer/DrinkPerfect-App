using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeOnClick : MonoBehaviour
{
   public void LoadScene(int level){
        // Load scene on level 'level'
        SceneManager.LoadScene(level);
   }
}
