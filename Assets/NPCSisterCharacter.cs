using UnityEngine;
using DialogueEditor;

public class NPCSisterCharacter : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!QuestManager.Instance.hasTalkedToSister)
            {
                QuestManager.Instance.hasTalkedToSister = true;
                Debug.Log("Du har nu snakket med s�steren.");
            }

            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
