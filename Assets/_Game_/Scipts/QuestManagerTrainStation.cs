using UnityEngine;

public class QuestManagerTrainStation : MonoBehaviour
{
    public static QuestManagerTrainStation Instance;

    [Header("Valgstatus")]
    public bool handleChoice = false;         // Denne sættes til true, hvis spilleren trækker i håndtaget
    public bool didNotPullLever = false;      // Denne sættes til true, hvis spilleren IKKE trak i håndtaget
    public bool choiceTaken = false;          // Denne sættes til true, når et valg er blevet taget
                                              // Dette Script genbruges over flere scener, så det mere ikke træk = dræb famillie. træk=red famillie
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Bevarer objektet mellem scener
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleChoice(bool choice)
    {
        handleChoice = choice;
        choiceTaken = true;

        if (!choice) // Hvis spilleren ikke trak i håndtaget
        {
            didNotPullLever = true;
            Debug.Log("Valg blev taget: Spilleren trak IKKE i håndtaget.");
        }
        else
        {
            Debug.Log("Valg blev taget: Spilleren trak i håndtaget.");
        }
    }
}
