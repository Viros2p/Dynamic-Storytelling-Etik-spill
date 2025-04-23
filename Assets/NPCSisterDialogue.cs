using UnityEngine;
using DialogueEditor;

public class NPCSisterDialogue : MonoBehaviour
{
    [Header("Dialog")]
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Start dialog
            ConversationManager.Instance.StartConversation(myConversation);

            // Fort�l FinishPoint_Park at spilleren har talt med s�steren
            FinishPoint_Park finish = FindObjectOfType<FinishPoint_Park>();
            if (finish != null)
            {
                finish.hasTalkedToSister = true;
                Debug.Log("S�steren er kontaktet � du kan nu g� hjem (n�r checkpoints ogs� er gennemf�rt).");
            }
            else
            {
                Debug.LogWarning("FinishPoint_Park blev ikke fundet i scenen.");
            }
        }
    }
}
