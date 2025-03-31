using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Sister_Dialogue : MonoBehaviour
{
    public NPCDialogue dialogueData;
    public Player_controller  dialoguePanel;
    public TMP_Text dialogueText, tMP_Text;

    private int dialogueIndex;
    private bool isTyping; 
}