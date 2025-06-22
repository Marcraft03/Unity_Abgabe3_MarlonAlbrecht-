using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Text winScoreText;   // Score + Zeit im Win-Screen
    public GameObject player;   // Referenz zum Player-Objekt

    private void Awake()
    {
        // Singleton: Nur eine Instanz
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // bleibt über Szenen hinweg erhalten
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Winscreen(int score, float time)
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);

            if (winScoreText != null)
            {
                winScoreText.text = "Score: " + score + "\nZeit: " + time.ToString("F1") + "s";
            }

            StopPlayer();  // Spieler deaktivieren
        }
    }

    public void Losescreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            StopPlayer();  // Spieler deaktivieren
        }
    }

    private void StopPlayer()
    {
        if (player != null)
        {
            player.SetActive(false); // deaktiviert den Spieler komplett
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameMap");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenü");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideWinScreen()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void HideGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
}