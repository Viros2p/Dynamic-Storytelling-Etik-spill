using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform checkpointsParent;  // Parent med alle checkpoints
    public List<Transform> targets = new List<Transform>();
    private int currentTargetIndex = 0;
    public Transform arrow;

    void Start()
    {
        // Fyld targets listen automatisk med alle children
        foreach (Transform child in checkpointsParent)
        {
            targets.Add(child);
        }
    }

    void Update()
    {
        if (currentTargetIndex < targets.Count)
        {
            Vector3 direction = targets[currentTargetIndex].position - arrow.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public void GoToNextTarget()
    {
        if (currentTargetIndex < targets.Count - 1)
        {
            currentTargetIndex++;
        }
        else
        {
            Debug.Log("Alle mål nået!");
            arrow.gameObject.SetActive(false); // dette deaktivere
        }
    }
}
