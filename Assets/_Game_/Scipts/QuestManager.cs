using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public bool hasTalkedToDad = false;
    public bool hasTalkedToMom = false;
    public bool hasTalkedToSister = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //  gemme mellem scener
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
