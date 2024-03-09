using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenuUI;
    private GameObject pontokUI;
    // private TMPro.TMP_Dropdown displayMode;
    void Start(){
        pauseMenuUI = GameObject.Find("PauseMenu");
        pontokUI   = GameObject.Find("Canvas"); 
        // displayMode = GameObject.Find("ResolutionDM").GetComponent<TMPro.TMP_Dropdown>();        
        // displayMode.onValueChanged.AddListener(delegate
        // {
        //     DisplayModeChange(displayMode.value);
        // });        
        TogglePauseMenu(pauseMenuUI, !pauseMenuUI.activeSelf);
        
    }
    // void DisplayModeChange(int value)
    // {
    //     if(value == 0) Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    //     else if(value==1) Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
    //     else Screen.fullScreenMode = FullScreenMode.Windowed;
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu(pontokUI, !pontokUI.activeSelf);
            TogglePauseMenu(pauseMenuUI, !pauseMenuUI.activeSelf);
        }
        if (pauseMenuUI.activeSelf && Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("OK.");
        }
        else if(pauseMenuUI.activeSelf && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("NOT OK.");
        }
    }

    public void TogglePauseMenu(GameObject c, bool allapot)
    {        
        c.SetActive(allapot);
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
