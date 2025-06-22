using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    [SerializeField] private playerMovementscript playerMovementScript;
    [SerializeField] private UI_Manager uiManager;

    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                patrolDestination = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Spieler berührt Enemy – Game Over!");
            if (playerMovementScript != null)
                playerMovementScript.canmove = false;

            if (uiManager != null)
                uiManager.Losescreen();
        }
    }
}