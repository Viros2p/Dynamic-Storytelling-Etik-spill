using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint_Park : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad;

    [Header("Progress")]
    public bool hasTalkedToSister = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            bool checkpointsOK = CheckpointManager.Instance != null && CheckpointManager.Instance.AllCheckpointsHit();

            if (checkpointsOK && hasTalkedToSister)
            {
                LoadScene();
            }
            else
            {
                if (!checkpointsOK)
                    Debug.Log("Du mangler at gå gennem nogle checkpoints.");
                if (!hasTalkedToSister)
                    Debug.Log("Du har ikke interageret med din søster endnu.");
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
