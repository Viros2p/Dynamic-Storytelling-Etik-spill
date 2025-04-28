using UnityEngine;

public class EnemyTriggerKill : MonoBehaviour
{
    [Header("Indstillinger")]
    [SerializeField] private Collider2D triggerCollider; // Collider NPC'en skal gå på
    [SerializeField] private GameObject[] npcsToKill; // Liste over NPC'er der skal dø

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjekker om det er den onde NPC som rammer triggeren
        if (other.CompareTag("Enemy")) // Sørg for, at din onde NPC har tagget "Enemy"
        {
            Debug.Log("Ond NPC aktiverede triggeren!");

            // Dræb de valgte NPC'er
            foreach (GameObject npc in npcsToKill)
            {
                if (npc != null)
                {
                    Debug.Log("Dræber: " + npc.name);
                    npc.SetActive(false); // Du kan også vælge npc.SetActive(false); hvis du ikke vil slette dem helt.  Destroy(npc)
                }
            }
        }
    }
}
