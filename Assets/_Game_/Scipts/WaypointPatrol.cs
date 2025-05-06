using System.Collections;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    [Header("Bevægelse")]
    public float speed = 2f;
    public bool loop = true;

    [Header("Waypoint-indstillinger")]
    public Transform waypointsParent;
    public float waitTimeAtEachWaypoint = 1.5f;

    private Transform[] waypoints;
    private int currentIndex = 0;
    private bool isWaiting = false;

    void Start()
    {
        // Hent alle waypoints
        int count = waypointsParent.childCount;
        waypoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            waypoints[i] = waypointsParent.GetChild(i);
        }

        if (waypoints.Length == 0)
        {
            Debug.LogError("Ingen waypoints fundet under " + waypointsParent.name);
        }

        Debug.Log("Starter patrulje mod: " + waypoints[currentIndex].name);
    }

    void Update()
    {
        if (isWaiting || waypoints.Length == 0) return;

        Transform target = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, target.position);

        // DEBUG
       // Debug.Log("NPC Pos: " + transform.position.ToString("F2") +
         //         " | Target Pos: " + target.position.ToString("F2") +
           //       " | Distance: " + distance.ToString("F2"));

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            StartCoroutine(WaitAndGoToNext());
        }
    }


    IEnumerator WaitAndGoToNext()
    {
        isWaiting = true;

        //Debug.Log("Ankommet ved: " + waypoints[currentIndex].name + " | Venter i " + waitTimeAtEachWaypoint + " sek.");

        yield return new WaitForSeconds(waitTimeAtEachWaypoint);

        currentIndex++;

        if (currentIndex >= waypoints.Length)
        {
            if (loop)
            {
                currentIndex = 0; // Start forfra
               // Debug.Log("Looping tilbage til første waypoint.");
            }
            else
            {
               // Debug.Log("Sidste waypoint nået – ingen loop.");
                yield break;
            }
        }

        //Debug.Log("Næste destination: " + waypoints[currentIndex].name);
        isWaiting = false;
    }
}
