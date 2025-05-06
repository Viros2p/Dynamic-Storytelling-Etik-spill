using UnityEngine;
using TMPro;

public class ObjectiveTextManager : MonoBehaviour
{
    [Header("Reference til UI tekst (TextMeshProUGUI)")]
    public TextMeshProUGUI objectiveTextUI;

    [Header("Liste over opgaver, der vises en ad gangen")]
    [TextArea(2, 5)]
    public string[] objectives;

    [Header("Startfarve på teksten")]
    public Color textColor = Color.white;

    private int currentObjectiveIndex = 0;

    void Start()
    {
        if (objectiveTextUI == null)
        {
            Debug.LogError("Objective Text UI mangler!");
            return;
        }

        UpdateObjective();
    }

    public void UpdateObjective()
    {
        if (objectives.Length > 0 && currentObjectiveIndex < objectives.Length)
        {
            objectiveTextUI.text = objectives[currentObjectiveIndex];
            objectiveTextUI.color = textColor;
        }
        else
        {
            objectiveTextUI.text = ""; // Ingen flere objectives
        }
    }

    public void NextObjective()
    {
        currentObjectiveIndex++;
        UpdateObjective();
    }

    public void SetTextColor(Color newColor)
    {
        textColor = newColor;
        if (objectiveTextUI != null)
        {
            objectiveTextUI.color = newColor;
        }
    }
}
