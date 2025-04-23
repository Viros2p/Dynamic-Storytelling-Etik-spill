using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint_Park : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Hvis der findes en CheckpointManager
            if (CheckpointManager.Instance != null)
            {
                if (CheckpointManager.Instance.AllCheckpointsHit())
                {
                    LoadScene();
                }
                else
                {
                    Debug.Log("Du mangler at gå gennem nogle checkpoints.");
                }
            }
            else
            {
                Debug.LogWarning("Der er ingen CheckpointManager i scenen. Skifter scene alligevel.");
                LoadScene();
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
