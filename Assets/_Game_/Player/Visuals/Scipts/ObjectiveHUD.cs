using UnityEngine;
using TMPro; // Husk, vi bruger TextMeshPro!

public class ObjectiveTextManager : MonoBehaviour
{
    [Header("Træk Objective Text UI ind her")]
    public TextMeshProUGUI objectiveTextUI;

    [Header("Liste over alle dine Objective tekster")]
    [TextArea(2, 5)]
    public string[] objectives;

    [Header("Startfarve for tekst")]
    public Color textColor = Color.white;

    private int currentObjectiveIndex = 0;

    void Start()
    {
        if (objectiveTextUI == null)
        {
            Debug.LogError("Objective Text UI er ikke sat! Træk din TextMeshProUGUI ind i inspector.");
            return;
        }

        UpdateObjective();
    }

    // Opdaterer teksten med nuværende objective
    public void UpdateObjective()
    {
        if (objectives.Length > 0 && currentObjectiveIndex < objectives.Length)
        {
            objectiveTextUI.text = objectives[currentObjectiveIndex];
            objectiveTextUI.color = textColor;
        }
        else
        {
            Debug.LogWarning("Ingen flere objectives i listen, eller index ude af rækkevidde.");
        }
    }

    // Kaldes når du vil skifte til næste objective
    public void NextObjective()
    {
        currentObjectiveIndex++;
        UpdateObjective();
    }

    // Hvis du vil ændre farven dynamisk også
    public void SetTextColor(Color newColor)
    {
        textColor = newColor;
        if (objectiveTextUI != null)
        {
            objectiveTextUI.color = newColor;
        }
    }
}
