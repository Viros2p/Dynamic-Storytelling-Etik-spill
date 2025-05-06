// SpriteFlipper.cs
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 lastPosition;

    void Start()
    {
        originalScale = transform.localScale;
        lastPosition = transform.position;
    }

    void Update()
    {
        float movementX = transform.position.x - lastPosition.x;

        if (movementX < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (movementX > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        lastPosition = transform.position;
    }
}
