using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using SimpleFileBrowser;
public class kepfeltolt : MonoBehaviour
{
    private DatabaseCommands db;
    void Start(){
        FileBrowser.SetFilters(true, new FileBrowser.Filter( "Images", ".jpg", ".png", ".jpeg" ) ); // Add extensions you want to allow
        FileBrowser.SetExcludedExtensions( ".lnk", ".tmp", ".zip", ".rar", ".exe" );
        FileBrowser.AddQuickLink( "Users", "C:\\Users", null );
    }
    public void OpenFileExplorer()
    {
        ShowLoadDialogCoroutine();
        // Check if file explorer is supported (not available in WebGL)
        // FileBrowser.ShowSaveDialog( ( paths ) => { Debug.Log( "Selected: " + paths[0] ); },
		// 						   () => { Debug.Log( "Canceled" ); }, FileBrowser.PickMode.Files, false, Application.dataPath+"/Temp", "hatkep.png", "Save As", "Save" );
        // Open file explorer
        
        // // string extensionFilter = string.Join(",", allowedExtensions);
        // string selectedFilePath = FileBrowser.OpenFilePanel("Open File", "", extensionFilter);

        // // Check if a file was selected
        // if (!string.IsNullOrEmpty(selectedFilePath))
        // {
        //     // Do something with the selected file
        //     statusText.text = "Selected file: " + selectedFilePath;
        //     // db = GetComponent<DatabaseCommands>();
        //     db.uploadFile(selectedFilePath);
        // }
        // else
        // {
        //     statusText.text = "No file selected.";
        // }
    }
    IEnumerator ShowLoadDialogCoroutine()
	{
		// Show a load file dialog and wait for a response from user
		// Load file/folder: file, Allow multiple selection: true
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Load File", Submit button text: "Load"
		yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.Files, true, null, null, "Select Files", "Load" );

		// Dialog is closed
		// Print whether the user has selected some files or cancelled the operation (FileBrowser.Success)
		Debug.Log( FileBrowser.Success );

		if( FileBrowser.Success )
			db.uploadFile( FileBrowser.Result[0] ); // FileBrowser.Result is null, if FileBrowser.Success is false
	}
}
