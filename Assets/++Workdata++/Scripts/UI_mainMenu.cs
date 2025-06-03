using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_mainMenu: MonoBehaviour
{
 

    public void Startm()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
    
}
