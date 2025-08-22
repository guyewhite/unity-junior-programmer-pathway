using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveDistance = 15f;
    [SerializeField] private float moveSpeed = 5f;
    
    private float currentPosition = 0f;
    private int direction = 1;
    private Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = transform.position;
        Debug.Log($"Move Script Started - Distance: {moveDistance}, Speed: {moveSpeed}");
    }

    void Update()
    {
        // Move the current position
        currentPosition += direction * moveSpeed * Time.deltaTime;
        
        // Check boundaries and reverse direction
        if (currentPosition >= moveDistance)
        {
            currentPosition = moveDistance;
            direction = -1;
            Debug.Log("Reached right boundary, reversing");
        }
        else if (currentPosition <= 0f)
        {
            currentPosition = 0f;
            direction = 1;
            Debug.Log("Reached left boundary, reversing");
        }
        
        // Apply the position
        Vector3 newPosition = originalPosition;
        newPosition.x += currentPosition;
        transform.position = newPosition;
    }
    
    // This will show the movement path in the Scene view
    void OnDrawGizmos()
    {
        Vector3 start = Application.isPlaying ? originalPosition : transform.position;
        Vector3 end = start + Vector3.right * moveDistance;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawWireSphere(start, 0.5f);
        Gizmos.DrawWireSphere(end, 0.5f);
    }
}