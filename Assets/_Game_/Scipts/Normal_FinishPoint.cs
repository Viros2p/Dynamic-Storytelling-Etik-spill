using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalFinishPoint : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Navnet på scenen der skal loades")]
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!string.IsNullOrWhiteSpace(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("Scenenavn mangler i Inspector på: " + gameObject.name);
            }
        }
    }
}
