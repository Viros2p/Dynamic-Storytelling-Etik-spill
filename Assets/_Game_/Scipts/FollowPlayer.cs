using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Spilleren
    public float followSpeed = 2f; // Hvor hurtigt objektet følger spilleren
    public float followRadius = 5f; // Radiusen, hvor objektet stopper med at følge

    private void Start()
    {
        // Hvis player ikke er tildelt i Inspector, find spilleren automatisk, Unødvendigt ngl. 
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;  
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Beregn afstanden mellem objektet og spilleren
            float distance = Vector3.Distance(transform.position, player.position);

            // Hvis afstanden er større end Radius, fortsæt med at følge spilleren
            if (distance > followRadius)
            {
                // Bevæge sig mod spilleren
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * followSpeed * Time.deltaTime;
            }
        }
    }
}
