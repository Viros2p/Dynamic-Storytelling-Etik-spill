using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private int checkpointsHit = 0;

    [Header("Indtast hvor mange checkpoints der skal rammes")]
    public int totalCheckpoints = 10;

    private ArrowPointer arrowPointer; // Reference til pilen

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Find pilen i scenen
        arrowPointer = FindFirstObjectByType<ArrowPointer>();
    }

    public void HitCheckpoint()
    {
        checkpointsHit++;
        Debug.Log("Checkpoint ramt: " + checkpointsHit + "/" + totalCheckpoints);

        // Fortæl pilen at vi skal videre
        if (arrowPointer != null)
        {
            arrowPointer.GoToNextTarget();
        }
    }

    public bool AllCheckpointsHit()
    {
        return checkpointsHit >= totalCheckpoints;
    }
}
