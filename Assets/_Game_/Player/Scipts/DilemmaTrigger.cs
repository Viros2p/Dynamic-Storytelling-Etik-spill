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

            // Deaktivér triggeren bagefter, så det kun skal ske én gang
            gameObject.SetActive(false);
        }
    }
}
