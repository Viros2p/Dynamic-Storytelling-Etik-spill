using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.HitCheckpoint();
            Destroy(gameObject); //´Fjerne checkpoint efter det er ramt
        }
    }
}
