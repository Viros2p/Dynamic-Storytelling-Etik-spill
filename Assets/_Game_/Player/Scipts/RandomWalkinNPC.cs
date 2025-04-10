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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewDestination();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoint) < range)
        {
            SetNewDestination();
        }

    }

    void SetNewDestination()
    {
        WayPoint = new Vector2(Random.Range(-MaxDistance, MaxDistance), Random.Range(-MaxDistance, MaxDistance));
    }

}