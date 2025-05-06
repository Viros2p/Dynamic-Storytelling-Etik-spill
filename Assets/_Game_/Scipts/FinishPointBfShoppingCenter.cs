using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPointBfShoppingCenter : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad;

    private MomCityConversationScript momConversationScript; // Reference til morens script

    private void Start()
    {
        // Finder morens script i scenen
        momConversationScript = FindObjectOfType<MomCityConversationScript>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            bool checkpointsOK = CheckpointManager.Instance != null && CheckpointManager.Instance.AllCheckpointsHit();

            if (checkpointsOK && momConversationScript != null && momConversationScript.HasTalkedToMom())
            {
                LoadScene();
            }
            else
            {
                if (!checkpointsOK)
                    Debug.Log("Du mangler at gå gennem nogle checkpoints.");
                if (momConversationScript == null)
                    Debug.LogError("Mors script kunne ikke findes.");
                else if (!momConversationScript.HasTalkedToMom())
                    Debug.Log("Du har ikke interageret med din mor endnu.");
            }
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene-navnet mangler.");
        }
    }
}
