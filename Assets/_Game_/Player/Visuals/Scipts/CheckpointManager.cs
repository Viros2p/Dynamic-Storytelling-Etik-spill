using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private int checkpointsHit = 0;

    [Header("Indtast hvor mange checkpoints der skal rammes")]
    public int totalCheckpoints = 10;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void HitCheckpoint()
    {
        checkpointsHit++;
        Debug.Log("Checkpoint ramt: " + checkpointsHit + "/" + totalCheckpoints);
    }

    public bool AllCheckpointsHit()
    {
        return checkpointsHit >= totalCheckpoints;
    }
}
