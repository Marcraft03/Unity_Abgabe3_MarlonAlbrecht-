using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameMap()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void QuitGame()
    {
        
        Application.Quit();
        Debug.Log("QuitGame wurde aufgerufen");  // zur Kontrolle im Editor
    }
}