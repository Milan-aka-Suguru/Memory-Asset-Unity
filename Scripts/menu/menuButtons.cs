using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{

    public void PlaySingle()
    {
        Debug.Log("Load scene 1");
        if (StateNameController.GridWidth == 0 || StateNameController.GridHeight == 0)
        {
            StateNameController.GridWidth = 4;
            StateNameController.GridHeight = 4;
        }
        SceneManager.LoadScene(1);
    }
    public void PlayMulti()
    {
        Debug.Log("Load scene 1");
        if (StateNameController.GridWidth == 0 || StateNameController.GridHeight == 0)
        {
            StateNameController.GridWidth = 4;
            StateNameController.GridHeight = 4;
        }
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
