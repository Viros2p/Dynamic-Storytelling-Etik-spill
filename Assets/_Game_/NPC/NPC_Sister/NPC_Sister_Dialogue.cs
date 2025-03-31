using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Sister_Dialogue : MonoBehaviour
{
    public NPCDialoguescript dialogueData;
    public Player_Controller  dialoguePanel;
    public TMP_Text dialogueText, tMP_Text;

    private int dialogueIndex;
    private bool isTyping; 
}