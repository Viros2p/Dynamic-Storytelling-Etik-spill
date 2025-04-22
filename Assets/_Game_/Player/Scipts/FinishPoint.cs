using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (AllRequiredNPCsTalkedTo())
            {
                TryLoadNextScene();
            }
            else
            {
                Debug.Log("Du har ikke talt med alle nødvendige personer endnu.");
            }
        }
    }

    // Tjek om spilleren har talt med far, mor og søster
    private bool AllRequiredNPCsTalkedTo()
    {
        return QuestManager.Instance.hasTalkedToDad &&
               QuestManager.Instance.hasTalkedToMom &&
               QuestManager.Instance.hasTalkedToSister;
    }

    // Forsøg at loade næste scene
    private void TryLoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneHandler.instance.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name not set on FinishPoint: " + gameObject.name);
        }
    }
}
