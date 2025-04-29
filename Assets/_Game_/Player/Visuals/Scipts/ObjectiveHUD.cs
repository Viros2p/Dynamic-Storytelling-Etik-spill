// ObjectiveTextManager.cs
using UnityEngine;
using TMPro;

public class ObjectiveTextManager : MonoBehaviour
{
    [Header("Skal systemet være aktivt i denne scene?")]
    public bool isActive = true;

    [Header("Tekstkomponent der skal opdateres")]
    public TextMeshProUGUI objectiveTextUI;

    [Header("Liste over objectives")]
    public Objective[] objectives;

    [Header("Farve på teksten")]
    public Color textColor = Color.white;

    private int currentIndex = 0;

    void Start()
    {
        if (!isActive)
        {
            gameObject.SetActive(false);
            return;
        }

        if (objectiveTextUI == null)
        {
            Debug.LogError("Du mangler at trække en TextMeshProUGUI ind i ObjectiveTextManager.");
            return;
        }

        if (objectives.Length > 0)
        {
            ShowObjective(currentIndex);
        }
    }

    void Update()
    {
        if (!isActive || objectives.Length == 0) return;

        if (currentIndex < objectives.Length && objectives[currentIndex].isCompleted)
        {
            currentIndex++;
            if (currentIndex < objectives.Length)
            {
                ShowObjective(currentIndex);
            }
            else
            {
                objectiveTextUI.text = "Alle mål er fuldført!";
            }
        }
    }

    void ShowObjective(int index)
    {
        if (objectiveTextUI != null && index < objectives.Length)
        {
            objectiveTextUI.text = objectives[index].text;
            objectiveTextUI.color = textColor;
        }
    }

    public void ResetObjectives()
    {
        foreach (var obj in objectives)
        {
            obj.isCompleted = false;
        }
        currentIndex = 0;
        ShowObjective(currentIndex);
    }
}
