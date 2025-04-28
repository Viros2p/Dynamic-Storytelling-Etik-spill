using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Sørg for din spiller har tag "Player"
        {
            FindFirstObjectByType<ArrowPointer>().GoToNextTarget();

            Destroy(gameObject);  // Hvis du vil fjerne målet når det er ramt
        }
    }
}
