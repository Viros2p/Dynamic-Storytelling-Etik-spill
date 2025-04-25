using UnityEngine;
using UnityEngine.SceneManagement;

public class Naked_FinishPoint : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string sceneIfSisterSaved; // Når man trækker i håndtaget
    [SerializeField] private string sceneIfChildSaved;  // Når man IKKE trækker i håndtaget

    private bool sceneChanged = false;

    private void Update()
    {
        if (!sceneChanged && QuestManagerTrainStation.Instance.choiceTaken)
        {
            if (QuestManagerTrainStation.Instance.handleChoice)
            {
                // Spilleren trak i håndtaget
                TryLoadNextScene(sceneIfSisterSaved);
            }
            else if (QuestManagerTrainStation.Instance.didNotPullLever)
            {
                // Spilleren valgte IKKE at trække i håndtaget
                TryLoadNextScene(sceneIfChildSaved);
            }

            sceneChanged = true; // Sikrer scenen kun skiftes én gang
        }
    }

    private void TryLoadNextScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Skifter til scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene-navn mangler i Naked_FinishPoint.");
        }
    }
}
