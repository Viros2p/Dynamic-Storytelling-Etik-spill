using UnityEngine;

public class AutomatedDoors : MonoBehaviour
{
    bool isPlayerInside = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if player is inside and trigger the animation accordingly
        if (isPlayerInside)
        {
            animator.SetBool("Door Open", true);
        }
        else
        {
            animator.SetBool("Door Open", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))  // Check if the collider is the player
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))  // Check if the collider is the player
        {
            isPlayerInside = false;
        }
    }
}
