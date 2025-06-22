using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private bool running = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (running)
        {
            // Timer läuft, Zeit kann z.B. für UI angezeigt werden
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    public float GetTime()
    {
        if (running)
            return Time.time - startTime;
        else
            return 0f;
    }
}

