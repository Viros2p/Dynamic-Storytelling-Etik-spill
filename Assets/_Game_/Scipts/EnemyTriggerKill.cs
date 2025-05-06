using UnityEngine;

public class EnemyTriggerKill : MonoBehaviour
{
    [Header("Indstillinger")]
    [SerializeField] private Collider2D triggerCollider; // Collider som den onde skal gå på
    [SerializeField] private GameObject[] npcsToKill; // Liste over NPC'er der skal dø

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjekker om det er den onde NPC som rammer triggeren
        if (other.CompareTag("Enemy")) 
        {
            Debug.Log("Ond NPC aktiverede triggeren!");

            // Dræb de valgte NPC'er
            foreach (GameObject npc in npcsToKill)
            {
                if (npc != null)
                {
                    Debug.Log("Dræber: " + npc.name);
                    npc.SetActive(false); // valgt at sætte dem til false frem for,   Destroy(npc)
                }
            }
        }
    }
}
