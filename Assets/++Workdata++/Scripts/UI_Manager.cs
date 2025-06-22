using UnityEngine;
using UnityEngine.UI;  // Für Text-Komponente

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Text winScoreText;  // Text-Komponente für Score + Zeit Anzeige

    private void Awake()
    {
        // Singleton Pattern, damit es nur eine Instanz gibt
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Methode für den Winscreen mit Score und Zeit
    public void Winscreen(int score, float time)
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (winScoreText != null)
            {
                winScoreText.text = "Score: " + score + "\nTime: " + time.ToString("F1") + "s";
            }
        }
    }

    // Methode für den Losescreen
    public void Losescreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // Optionale Helfer: Win- oder GameOver-Bildschirme verbergen
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