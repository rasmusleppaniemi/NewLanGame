using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputScore;
    [SerializeField] private TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;

    private void Start()
    {
        // Calculate the score when the ScoreManager is instantiated
        int finalScore = GameManager.Instance.CalculateScore();
        inputScore.text = finalScore.ToString();
    }

    public void SubmitScore()
    {
        // Use the calculated score
        int finalScore = GameManager.Instance.CalculateScore();
        submitScoreEvent.Invoke(inputName.text, finalScore);
    }
}
