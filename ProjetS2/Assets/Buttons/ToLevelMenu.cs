using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToLevelMenu : MonoBehaviour
{
    public void PlayButtonScript()
    {
        SceneManager.LoadScene("LevelsMenu");
    }

}

