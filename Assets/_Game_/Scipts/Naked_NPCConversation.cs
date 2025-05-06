using UnityEngine;
using DialogueEditor;
//Helt basal Dialog starter 
public class Naked_navn : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
