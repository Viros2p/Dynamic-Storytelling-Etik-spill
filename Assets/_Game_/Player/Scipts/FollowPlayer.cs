using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Spilleren som NPC'en skal f�lge
    public float followRadius = 3f;  // Afstand hvor NPC'en begynder at f�lge spilleren
    public float moveSpeed = 2f;  // Hvor hurtigt NPC'en skal bev�ge sig
    private bool isFollowing = false;  // Tjekker om NPC'en er t�t nok p� spilleren for at f�lge

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

        // Hvis NPC'en er inden for radiusen, f�lg spilleren
        if (isFollowing)
        {
            Follow();
        }
    }

    private void Follow()
    {
        // G�r NPC'en til at f�lge spilleren
        Vector3 direction = (player.position - transform.position).normalized;  // Beregn retningen mod spilleren
        transform.position += direction * moveSpeed * Time.deltaTime;  // Flyt NPC'en mod spilleren
    }
}
