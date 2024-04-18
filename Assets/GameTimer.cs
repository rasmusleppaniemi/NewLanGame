using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float ElapsedTime { get; private set; }
    public bool GameOn = true;

    private void Update()
    {
        if (GameOn)
        {
            Timer();
        }
    }

    private void Timer()
    {
        ElapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(ElapsedTime / 60);
        int seconds = Mathf.FloorToInt(ElapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
