using UnityEngine;
using DialogueEditor;

public class NPCMomCharacter : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!QuestManager.Instance.hasTalkedToMom)
            {
                QuestManager.Instance.hasTalkedToMom = true;
                Debug.Log("Du har nu snakket med moren.");
            }

            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
