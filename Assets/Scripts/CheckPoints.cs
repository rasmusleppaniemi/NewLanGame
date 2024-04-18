using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public CheckpointSystem checkPointSystem;

    public void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Passed Checkpoint");
            checkPointSystem.CheckPoint(this.gameObject, true);
        }
    }
}
