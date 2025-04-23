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

            // Fortæl FinishPoint_Park at spilleren har talt med søsteren
            FinishPoint_Park finish = FindObjectOfType<FinishPoint_Park>();
            if (finish != null)
            {
                finish.hasTalkedToSister = true;
                Debug.Log("Søsteren er kontaktet – du kan nu gå hjem (når checkpoints også er gennemført).");
            }
            else
            {
                Debug.LogWarning("FinishPoint_Park blev ikke fundet i scenen.");
            }
        }
    }
}
