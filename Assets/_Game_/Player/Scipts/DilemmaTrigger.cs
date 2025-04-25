using UnityEngine;
using DialogueEditor;

public class DilemmaTrigger : MonoBehaviour
{
    public NPCConversation myConversation;
    public WaypointMover trainPatroller; // Rigtig klasse-navn her!

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            Debug.Log("Dilemma-samtale startet!");

            if (myConversation != null)
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }

            if (trainPatroller != null)
            {
                trainPatroller.isMoving = true; // Aktivér toget
                Debug.Log("Toget begynder at patruljere!");
            }
            else
            {
                Debug.Log("Toget er Stoppet eller TrainPatroller er ikke sat i Inspector!");
            }
        }
    }
}
