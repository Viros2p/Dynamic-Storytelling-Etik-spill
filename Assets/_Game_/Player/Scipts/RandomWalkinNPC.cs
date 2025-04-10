using UnityEngine;

public class RandomWalkinNPC : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    [SerializeField] float stuckCheckDelay = 1f; // Hvor lang tid f�r vi tjekker for "stuck"

    private Vector2 wayPoint;
    private Vector2 lastPosition;
    private float stuckTimer = 0f;

    void Start()
    {
        SetNewDestination();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Bev�g mod waypoint
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        // Skift retning hvis vi er t�t p� m�let
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        // Tjek for "stuck"
        stuckTimer += Time.deltaTime;
        if (stuckTimer >= stuckCheckDelay)
        {
            float distanceMoved = Vector2.Distance(transform.position, lastPosition);
            if (distanceMoved < 0.05f) // Ikke flyttet sig nok = sidder fast
            {
                SetNewDestination(); // V�lg ny retning
            }

            lastPosition = transform.position;
            stuckTimer = 0f;
        }
    }

    void SetNewDestination()
    {
        Vector2 currentPosition = transform.position;
        wayPoint = new Vector2(
            currentPosition.x + Random.Range(-maxDistance, maxDistance),
            currentPosition.y + Random.Range(-maxDistance, maxDistance)
        );
    }
}
