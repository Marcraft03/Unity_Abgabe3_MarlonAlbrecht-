using TMPro;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private int coinCount = 0;
    private int diamondCount = 0;

    [SerializeField] private TMP_Text coinText;     // Zeigt: Gold: X
    [SerializeField] private TMP_Text diamondText;  // Zeigt: Diamant: X

    [SerializeField] private playerMovementscript playerMovementScript;
    [SerializeField] private UI_Manager uiManager;

    private void Start()
    {
        UpdateUI();  // Startet mit Gold: 0, Diamant: 0
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
            uiManager.Losescreen();
        }
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Gold: " + coinCount;
        }
        if (diamondText != null)
        {
            diamondText.text = "Diamant: " + diamondCount;
        }
        

    }

    private void CheckWinCondition()
    {
        int score = coinCount * 5 + diamondCount * 10;

        if (score >= 10)
        {
            float time = 0f;

            if (uiManager != null)
            {
                uiManager.Winscreen(score, time); 
            }
            
        }

    }
    
}