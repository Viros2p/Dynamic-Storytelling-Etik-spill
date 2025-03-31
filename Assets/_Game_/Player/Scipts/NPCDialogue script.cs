using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNpcDialogue", menuName = "NPCDialogue")]
public class NPCDialoguescript : ScriptableObject
{
    public string NpcName;
    public Sprite NpcPortraits;
    public string[] DialogueLines;
    public bool[] AutoProgressLines;
    public float AutoProgressDelay = 1.5f;
    public float TypingSpeed = 0.05f;
    public AudioClip VoiceSound;
    public float VoicePitch = 1f;
   

}
