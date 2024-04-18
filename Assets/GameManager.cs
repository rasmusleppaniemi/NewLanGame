using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private float totalElapsedTime = 0f;
    public float TotalElapsedTime => totalElapsedTime;

    private int initialScore = 100000; // Change initial score as needed

    private void Awake()
    {
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

    public void AddElapsedTime(float elapsedTime)
    {
        totalElapsedTime += elapsedTime;
    }

    public int CalculateScore()
    {
        float deductionPercentage = 0.005f;
        int finalScore = Mathf.Max(0, initialScore - Mathf.RoundToInt(initialScore * deductionPercentage * totalElapsedTime));
        return finalScore;
    }
}
