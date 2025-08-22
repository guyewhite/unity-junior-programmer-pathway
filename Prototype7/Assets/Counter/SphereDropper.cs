using UnityEngine;
using UnityEngine.InputSystem;

public class SphereDropper : MonoBehaviour
{
    [Header("Sphere Settings")]
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private float dropForce = 0f;
    [SerializeField] private float spawnHeight = 10f;
    [SerializeField] private float destroyHeight = 0f;
    
    [Header("Spawn Settings")]
    [SerializeField] private bool allowMultipleDrops = true;
    [SerializeField] private float dropCooldown = 0.5f;
    
    private float lastDropTime = 0f;
    
    void Start()
    {
        Debug.Log("SphereDropper Started!");
        
        // Create a sphere prefab if none is assigned
        if (spherePrefab == null)
        {
            Debug.LogWarning("No sphere prefab assigned! Creating default sphere.");
            CreateDefaultSpherePrefab();
        }
        else
        {
            Debug.Log($"Sphere prefab assigned: {spherePrefab.name}");
        }
    }
    
    void Update()
    {
        // Check for space bar press using the new Input System
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Space bar pressed!");
            
            // Check if enough time has passed since last drop
            if (Time.time - lastDropTime >= dropCooldown)
            {
                DropSphere();
                lastDropTime = Time.time;
            }
            else
            {
                Debug.Log($"Cooldown active. Wait {dropCooldown - (Time.time - lastDropTime)} seconds.");
            }
        }
    }
    
    void DropSphere()
    {
        // Calculate spawn position at specified height
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            spawnHeight,
            transform.position.z
        );
        
        // Instantiate the sphere
        GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        
        // Add Rigidbody if it doesn't have one
        Rigidbody rb = newSphere.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newSphere.AddComponent<Rigidbody>();
        }
        
        // Apply downward force if specified
        if (dropForce > 0)
        {
            rb.AddForce(Vector3.down * dropForce, ForceMode.Impulse);
        }
        
        // Add the destroyer component to handle automatic destruction
        SphereDestroyer destroyer = newSphere.AddComponent<SphereDestroyer>();
        destroyer.destroyHeight = destroyHeight;
        
        // Set the sphere name for organization
        newSphere.name = $"DroppedSphere_{System.DateTime.Now.Ticks}";
        
        Debug.Log($"Sphere dropped from height: {spawnHeight}");
    }
    
    void CreateDefaultSpherePrefab()
    {
        // Create a default sphere GameObject
        spherePrefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spherePrefab.name = "SpherePrefab";
        
        // Add Rigidbody
        spherePrefab.AddComponent<Rigidbody>();
        
        // Add a material if you want a specific color
        Renderer renderer = spherePrefab.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red;
        }
        
        // Make it a prefab by moving it out of the scene
        spherePrefab.SetActive(false);
        
        Debug.Log("Created default sphere prefab");
    }
    
    void OnDrawGizmos()
    {
        // Show spawn position in Scene view
        Gizmos.color = Color.cyan;
        Vector3 spawnPos = new Vector3(transform.position.x, spawnHeight, transform.position.z);
        Gizmos.DrawWireSphere(spawnPos, 0.5f);
        
        // Draw line from spawn to destroy height
        Gizmos.color = Color.red;
        Vector3 destroyPos = new Vector3(transform.position.x, destroyHeight, transform.position.z);
        Gizmos.DrawLine(spawnPos, destroyPos);
        Gizmos.DrawWireCube(destroyPos, new Vector3(2, 0.1f, 2));
    }
}