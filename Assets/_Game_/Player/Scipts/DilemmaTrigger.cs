using UnityEngine;
using DialogueEditor;

public class DilemmaTrigger : MonoBehaviour
{
    public NPCConversation myConversation; // Drag din samtale ind i Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(myConversation);
            Debug.Log("Dilemma-samtale startet!");

            // Deaktiv�r triggeren bagefter, s� det kun skal ske �n gang
            gameObject.SetActive(false);
        }
    }
}
