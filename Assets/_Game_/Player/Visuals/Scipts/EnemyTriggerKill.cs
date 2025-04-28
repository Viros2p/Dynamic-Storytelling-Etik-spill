using UnityEngine;

public class EnemyTriggerKill : MonoBehaviour
{
    [Header("Indstillinger")]
    [SerializeField] private Collider2D triggerCollider; // Collider NPC'en skal g� p�
    [SerializeField] private GameObject[] npcsToKill; // Liste over NPC'er der skal d�

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tjekker om det er den onde NPC som rammer triggeren
        if (other.CompareTag("Enemy")) // S�rg for, at din onde NPC har tagget "Enemy"
        {
            Debug.Log("Ond NPC aktiverede triggeren!");

            // Dr�b de valgte NPC'er
            foreach (GameObject npc in npcsToKill)
            {
                if (npc != null)
                {
                    Debug.Log("Dr�ber: " + npc.name);
                    npc.SetActive(false); // Du kan ogs� v�lge npc.SetActive(false); hvis du ikke vil slette dem helt.  Destroy(npc)
                }
            }
        }
    }
}
