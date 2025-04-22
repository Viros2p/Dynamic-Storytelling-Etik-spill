using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Spilleren som NPC'en skal følge
    public float followRadius = 3f;  // Afstand hvor NPC'en begynder at følge spilleren
    public float moveSpeed = 2f;  // Hvor hurtigt NPC'en skal bevæge sig
    private bool isFollowing = false;  // Tjekker om NPC'en er tæt nok på spilleren for at følge

    private void Update()
    {
        // Beregn afstanden mellem NPC og spiller
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followRadius)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // Hvis NPC'en er inden for radiusen, følg spilleren
        if (isFollowing)
        {
            Follow();
        }
    }

    private void Follow()
    {
        // Gør NPC'en til at følge spilleren
        Vector3 direction = (player.position - transform.position).normalized;  // Beregn retningen mod spilleren
        transform.position += direction * moveSpeed * Time.deltaTime;  // Flyt NPC'en mod spilleren
    }
}
