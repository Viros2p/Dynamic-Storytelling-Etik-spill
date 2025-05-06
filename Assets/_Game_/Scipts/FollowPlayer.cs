using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Spilleren
    public float followSpeed = 2f; // Hvor hurtigt objektet f�lger spilleren
    public float followRadius = 5f; // Radiusen, hvor objektet stopper med at f�lge

    private void Start()
    {
        // Hvis player ikke er tildelt i Inspector, find spilleren automatisk, Un�dvendigt ngl. 
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

            // Hvis afstanden er st�rre end Radius, forts�t med at f�lge spilleren
            if (distance > followRadius)
            {
                // Bev�ge sig mod spilleren
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * followSpeed * Time.deltaTime;
            }
        }
    }
}
