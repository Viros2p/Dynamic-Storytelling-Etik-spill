using UnityEngine;
using DialogueEditor;

public class NPCDadCharacter : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!QuestManager.Instance.hasTalkedToDad)
            {
                QuestManager.Instance.hasTalkedToDad = true;
                Debug.Log("Du har nu snakket med faren.");
            }

            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
