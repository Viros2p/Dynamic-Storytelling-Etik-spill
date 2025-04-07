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
    //public float moveSpeed = 2f;  // Hastighed for NPC's bev�gelse
    private Vector3 direction;
    private Animator animator;  // Reference til animatoren


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewDestination();


        // F� fat i animatoren
        animator = GetComponent<Animator>();

        // Start bev�gelsen
        direction = Vector3.right;  // NPC'en skal bev�ge sig mod h�jre
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoint) < range)
        {
            SetNewDestination();
        }

        // Bev�g NPC'en mod h�jre (p� X-aksen)
        transform.Translate(direction * speed * Time.deltaTime);

        // Tjek om NPC'en bev�ger sig mod h�jre
        if (direction == Vector3.right && transform.localScale.x < 0)
        {
            // Flip animationen
            Flip();
        }
        // Tjek om NPC'en bev�ger sig mod venstre
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