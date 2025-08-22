using UnityEngine;

public class SphereDestroyer : MonoBehaviour
{
    public float destroyHeight = 0f;
    private bool hasTriggeredDestroy = false;
    
    void Update()
    {
        // Check if the sphere has fallen below the destroy height
        if (transform.position.y <= destroyHeight && !hasTriggeredDestroy)
        {
            hasTriggeredDestroy = true;
            DestroySphere();
        }
    }
    
    void DestroySphere()
    {
        // Log destruction for debugging
        Debug.Log($"Destroying sphere at height: {transform.position.y}");
        
        // Optional: Add particle effect or sound before destroying
        // You could instantiate an explosion effect here
        
        // Destroy the game object
        Destroy(gameObject);
    }
    
    // Visual indicator in Scene view
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 destroyLine = new Vector3(transform.position.x, destroyHeight, transform.position.z);
        Gizmos.DrawLine(transform.position, destroyLine);
    }
}