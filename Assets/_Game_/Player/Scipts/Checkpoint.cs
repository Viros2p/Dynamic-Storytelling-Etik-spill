using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool hasBeenHit = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !hasBeenHit)
        {
            hasBeenHit = true;
            CheckpointManager.Instance.HitCheckpoint();
            gameObject.SetActive(false); // Hvis du vil "fjerne" checkpointet bagefter
        }
    }
}
