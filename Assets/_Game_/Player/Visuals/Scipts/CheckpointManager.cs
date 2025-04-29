using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private int checkpointsHit = 0;

    [Header("Indtast hvor mange checkpoints der skal rammes")]
    public int totalCheckpoints = 10;

    [Header("Reference til ObjectiveTextManager")]
    public ObjectiveTextManager objectiveManager;

    private ArrowPointer arrowPointer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        arrowPointer = FindFirstObjectByType<ArrowPointer>();
    }

    public void HitCheckpoint()
    {
        checkpointsHit++;
        Debug.Log("Checkpoint ramt: " + checkpointsHit + "/" + totalCheckpoints);

        if (arrowPointer != null)
        {
            arrowPointer.GoToNextTarget();
        }

        if (AllCheckpointsHit())
        {
            Debug.Log("Alle checkpoints er ramt!");

            // Marker objektivet som færdigt
            if (objectiveManager != null && objectiveManager.objectives.Length > 0)
            {
                objectiveManager.objectives[0].isCompleted = true;
            }
        }
    }

    public bool AllCheckpointsHit()
    {
        return checkpointsHit >= totalCheckpoints;
    }
}
