using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNpcDialogue", menuName = "NPC Dialogue")];
public class NPCDialoguescript : ScriptableObject
{
    public string NpcName;
    public Sprite NpcPortraits;
    public string[] DialogueLines;
    public float TypingSpeed = 0.05f;
    public AudioClip VoiceSound;
    public float VoicePitch = 1f;
    public bool[] AutoProgressLines;
    public float AutoProgressDelay = 1.5f;

}
