using UnityEngine;

public class RandomWalkinNPC : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float MaxDistance;

    Vector2 WayPoint;

    //NPC Flipping 
    //public float moveSpeed = 2f;  // Hastighed for NPC's bevægelse
    private Vector3 direction;
    private Animator animator;  // Reference til animatoren


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewDestination();


        // Få fat i animatoren
        animator = GetComponent<Animator>();

        // Start bevægelsen
        direction = Vector3.right;  // NPC'en skal bevæge sig mod højre
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoint) < range)
        {
            SetNewDestination();
        }

        // Bevæg NPC'en mod højre (på X-aksen)
        transform.Translate(direction * speed * Time.deltaTime);

        // Tjek om NPC'en bevæger sig mod højre
        if (direction == Vector3.right && transform.localScale.x < 0)
        {
            // Flip animationen
            Flip();
        }
        // Tjek om NPC'en bevæger sig mod venstre
        else if (direction == Vector3.left && transform.localScale.x > 0)
        {
            // Flip animationen
            Flip();
        }

    }

    void SetNewDestination()
    {
        WayPoint = new Vector2(Random.Range(-MaxDistance, MaxDistance), Random.Range(-MaxDistance, MaxDistance));
    }

    void Flip()
    {
        // Flip X-aksen af NPC'ens localScale
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}