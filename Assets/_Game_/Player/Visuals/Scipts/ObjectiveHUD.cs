using UnityEngine;
using TMPro; // Husk, vi bruger TextMeshPro!

public class ObjectiveTextManager : MonoBehaviour
{
    [Header("Tr�k Objective Text UI ind her")]
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
            Debug.LogError("Objective Text UI er ikke sat! Tr�k din TextMeshProUGUI ind i inspector.");
            return;
        }

        UpdateObjective();
    }

    // Opdaterer teksten med nuv�rende objective
    public void UpdateObjective()
    {
        if (objectives.Length > 0 && currentObjectiveIndex < objectives.Length)
        {
            objectiveTextUI.text = objectives[currentObjectiveIndex];
            objectiveTextUI.color = textColor;
        }
        else
        {
            Debug.LogWarning("Ingen flere objectives i listen, eller index ude af r�kkevidde.");
        }
    }

    // Kaldes n�r du vil skifte til n�ste objective
    public void NextObjective()
    {
        currentObjectiveIndex++;
        UpdateObjective();
    }

    // Hvis du vil �ndre farven dynamisk ogs�
    public void SetTextColor(Color newColor)
    {
        textColor = newColor;
        if (objectiveTextUI != null)
        {
            objectiveTextUI.color = newColor;
        }
    }
}
