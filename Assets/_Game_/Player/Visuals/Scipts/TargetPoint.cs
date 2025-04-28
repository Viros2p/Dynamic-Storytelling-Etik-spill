using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // S�rg for din spiller har tag "Player"
        {
            FindFirstObjectByType<ArrowPointer>().GoToNextTarget();

            Destroy(gameObject);  // Hvis du vil fjerne m�let n�r det er ramt
        }
    }
}
