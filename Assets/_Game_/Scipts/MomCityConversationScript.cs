using DialogueEditor;
using UnityEngine;

public class MomCityConversationScript : MonoBehaviour
{
    public NPCConversation myConversation;
    private bool hasTalkedToMom = false; // Lokal variabel, det smarte er at det kan sættes true i Inspector 

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!hasTalkedToMom)
            {
                hasTalkedToMom = true;
                Debug.Log("Du har nu snakket med moren.");
            }

            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    public bool HasTalkedToMom()
    {
        return hasTalkedToMom;
    }
}
