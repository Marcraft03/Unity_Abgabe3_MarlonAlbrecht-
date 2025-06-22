using TMPro;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private int coinCount = 0;
    private int diamondCount = 0;

    [SerializeField] private TMP_Text coinText;       // zeigt "Gold: + Punkte"
    [SerializeField] private TMP_Text diamondText;    // zeigt "Diamant: + Punkte"
    [SerializeField] private TMP_Text scoreText;      // zeigt "Gesamt: + Punkte"
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private playerMovementscript playerMovementScript;
    [SerializeField] private UI_Manager uiManager;

    [SerializeField] private float timeLeft = 60f;
    private bool timerRunning = true;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (!timerRunning) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            timerRunning = false;
            playerMovementScript.canmove = false;
            if (uiManager != null)
                uiManager.Losescreen();
        }

        if (timerText != null)
            timerText.text = "Zeit: " + Mathf.CeilToInt(timeLeft);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoldCoin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            UpdateUI();
            CheckWinCondition();
        }
        else if (other.CompareTag("Diamond"))
        {
            diamondCount++;
            Destroy(other.gameObject);
            UpdateUI();
            CheckWinCondition();
        }
        else if (other.CompareTag("Enemy"))
        {
            playerMovementScript.canmove = false;
            if (uiManager != null)
                uiManager.Losescreen();
        }
    }

    private void UpdateUI()
    {
        int goldPoints = coinCount * 5;
        int diamondPoints = diamondCount * 10;
        int totalScore = goldPoints + diamondPoints;

        if (coinText != null)
            coinText.text = "Gold: " + goldPoints;
        if (diamondText != null)
            diamondText.text = "Diamant: " + diamondPoints;
        if (scoreText != null)
            scoreText.text = "Gesamt: " + totalScore;
    }

    private void CheckWinCondition()
    {
        int score = coinCount * 5 + diamondCount * 10;

        if (score >= 50) // Mindestpunktzahl
        {
            timerRunning = false;
            playerMovementScript.canmove = false;
            if (uiManager != null)
                uiManager.Winscreen(score, timeLeft);
        }
    }
}
