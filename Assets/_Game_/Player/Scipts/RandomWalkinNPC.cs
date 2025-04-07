using UnityEngine;

public class RandomWalkinNPC : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float MaxDistance;

    Vector2 WayPoint;
    Animator animator; // Animator reference

    void Start()
    {
        SetNewDestination();
        animator = GetComponent<Animator>(); // Getting Animator component
    }

    void Update()
    {
        // Move NPC towards the waypoint
        transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);

        // Check if NPC has reached the waypoint
        if (Vector2.Distance(transform.position, WayPoint) < range)
        {
            SetNewDestination();
        }

        // Determine direction for animation flip
        if (transform.position.x < WayPoint.x)
        {
            // NPC moving right
            animator.SetBool("MovingRight", true);
        }
        else
        {
            // NPC moving left
            animator.SetBool("MovingRight", false);
        }
    }

    void SetNewDestination()
    {
        WayPoint = new Vector2(Random.Range(-MaxDistance, MaxDistance), Random.Range(-MaxDistance, MaxDistance));
    }
}