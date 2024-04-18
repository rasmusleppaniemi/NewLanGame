using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameTimer gameTimer = GameObject.FindObjectOfType<GameTimer>(); // Find the GameTimer component in the scene

        if (gameTimer != null)
        {
            gameTimer.GameOn = false;

            // Add elapsed time to the GameManager
            GameManager.Instance.AddElapsedTime(gameTimer.ElapsedTime);

            // Get the index of the next scene in the build settings
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Check if there is a next scene in the build settings
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                // Load the next scene in the build settings
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("No next scene found in the build settings.");
            }
        }
        else
        {
            Debug.LogWarning("GameTimer not found in the scene.");
        }
    }
}
