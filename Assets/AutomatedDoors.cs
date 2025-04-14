using UnityEngine;

public class AutomatedDoors : MonoBehaviour
{
    bool isPlayerInside = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Door script initialized.");
    }

    void Update()
    {
        if (isPlayerInside)
        {
            animator.SetBool("Door Open", true);
            Debug.Log("Door opening.");
        }
        else
        {
            animator.SetBool("Door Open", false);
            Debug.Log("Door closing.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("Player entered the door trigger.");
        }
        else
        {
            Debug.Log("Another object entered the door trigger: " + collider.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("Player exited the door trigger.");
        }
    }
}
