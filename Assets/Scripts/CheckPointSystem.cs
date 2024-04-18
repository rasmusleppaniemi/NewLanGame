using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public List<GameObject> CheckPoints = new List<GameObject>();
    public GameObject FinishLine;

    // Track the activation status of each checkpoint
    private Dictionary<GameObject, bool> checkpointStatus = new Dictionary<GameObject, bool>();

    void Start()
    {
        FinishLine.SetActive(false);
        foreach (GameObject checkpoint in CheckPoints)
        {
            Debug.Log("Checkpoints" + checkpoint);
            checkpointStatus.Add(checkpoint, false);
        }
    }

    public void CheckPoint(GameObject checkpoint, bool passedThrough)
    {
        if (checkpointStatus.ContainsKey(checkpoint))
        {
            // Update checkpoint status
            checkpointStatus[checkpoint] = passedThrough;

            // Check if all checkpoints have been passed
            bool allCheckpointsActivated = true;
            foreach (bool status in checkpointStatus.Values)
            {
                if (!status)
                {
                    allCheckpointsActivated = false;
                    break;
                }
            }

            // If all checkpoints are activated, unlock the finish line
            if (allCheckpointsActivated)
            {
                FinishLine.SetActive(true);
            }
        }
    }
}
