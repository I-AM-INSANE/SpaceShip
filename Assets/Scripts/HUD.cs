using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text sessionTimer;
    float timeInGame;
    int seconds = 0;
    int minutes = 0;
    int hourses = 0;
    bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        sessionTimer = GameObject.FindGameObjectWithTag("SessionTimer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timeInGame += Time.deltaTime;

            seconds = (int)timeInGame % 60;
            minutes = (int)timeInGame / 60 % 3600;
            hourses = (int)timeInGame / 3600;

            sessionTimer.text = $"Time in game: {hourses}h  {minutes}m  {seconds}s";
        }
    }

    public void Stop()
    {
        running = false;
    }
}
