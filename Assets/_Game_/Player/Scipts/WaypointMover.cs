using System.Collections;
using Unity.Properties;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    public Transform WaypointParent;
    public float moveSpeed = 2f;
    public float WaitTime = 2f;
    public bool LoopWaypoint = true;

    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool IsWaiting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[WaypointParent.childCount];
       

        for (int i = 0; i < WaypointParent.childCount; i++)
        {
            waypoints[i] = WaypointParent.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Hun har en pause controlle som gør at de ikke går imens man snakker, fårhpbenligt virker det uden.
        if (!IsWaiting)
            {
                MoveToWaypoint();
            }
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        IsWaiting = true;
        yield return new WaitForSeconds (WaitTime);

        currentWaypointIndex = LoopWaypoint ? (currentWaypointIndex +1) %  waypoints.Length : Mathf.Min(currentWaypointIndex +1, waypoints.Length -1);

        IsWaiting = false;
    }
}
