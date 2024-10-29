using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject gameOver;

    //private void Start()
    //{
    //    StartTimer();
    //}


    // Update is called once per frame
    void Update()
    {
        Invoke("StartTimer", 0.5f);
        if (remainingTime > 0)
        {   
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            GameOver();
        }
    }

    public void StartTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{00:00}: {1:00}", minutes, seconds);
        
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
}
