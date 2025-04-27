using System.Collections;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    #region Public Variables
    public Transform WaypointParent;
    public float moveSpeed = 2f;
    public float WaitTime = 2f;
    public bool LoopWaypoint = true;
    public bool isMoving = true; // Dette kan tændes/slukkes udefra
    #endregion

    #region Private Variables
    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool IsWaiting;
    #endregion

    #region Unity Methods
    void Start()
    {
        waypoints = new Transform[WaypointParent.childCount];

        for (int i = 0; i < WaypointParent.childCount; i++)
        {
            waypoints[i] = WaypointParent.GetChild(i);
        }
    }

    void Update()
    {
        // Hvis vi ikke må bevæge os eller venter, gør vi ingenting
        if (!isMoving || IsWaiting)
            return;

        MoveToWaypoint();
    }
    #endregion

    #region Movement Logic
    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        IsWaiting = true;
        yield return new WaitForSeconds(WaitTime);

        currentWaypointIndex = LoopWaypoint
            ? (currentWaypointIndex + 1) % waypoints.Length
            : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);

        IsWaiting = false;
    }
    #endregion
}
