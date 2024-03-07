using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenuUI;
    private GameObject pontokUI;

    void Start(){
        pauseMenuUI = GameObject.Find("PauseMenu");
        pontokUI   = GameObject.Find("Canvas");        
        TogglePauseMenu(pauseMenuUI, !pauseMenuUI.activeSelf);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(pontokUI, !pontokUI.activeSelf);
            TogglePauseMenu(pauseMenuUI, !pauseMenuUI.activeSelf);
        }
    }

    public void TogglePauseMenu(GameObject c, bool allapot)
    {        
        c.SetActive(allapot);
        Time.timeScale = c.activeSelf ? 0f : 1f; // Freeze time when paused
    }

    // public void Resume()
    // {
    //     TogglePauseMenu();
    // }

    public void QuitGame()
    {
        // Add code here to quit the game (e.g., Application.Quit())
    }
}
