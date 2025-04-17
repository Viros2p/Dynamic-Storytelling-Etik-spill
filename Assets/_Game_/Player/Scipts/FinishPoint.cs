using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
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
}
