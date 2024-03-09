using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // Layer mask to exclude the player from raycasting
    public LayerMask playerLayer;

    // Transparency material
    public Material transparentMaterial;

    // Original material of the object
    private Material originalMaterial;

    // Reference to the object's renderer
    private Renderer objectRenderer;

    // Transparency level (0 for fully opaque, 1 for fully transparent)
    [Range(0f, 1f)]
    public float transparency = 0.5f;

    private void Start()
    {
        // Get the object's renderer component
        objectRenderer = GetComponent<Renderer>();

        // Store the original material
        originalMaterial = objectRenderer.material;
    }

    private void Update()
    {
        // Check if the player is behind the object
        if (IsPlayerBehind())
        {
            // Set the object's material to the transparent material with the specified transparency
            Color transparentColor = originalMaterial.color;
            transparentColor.a = transparency;
            transparentMaterial.color = transparentColor;

            objectRenderer.material = transparentMaterial;
        }
        else
        {
            // Set the object's material back to the original material
            objectRenderer.material = originalMaterial;
        }
    }

    private bool IsPlayerBehind()
    {
        // Calculate the direction from the object to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Cast a ray from the object towards the player
        Ray ray = new Ray(transform.position, directionToPlayer);

        // Check if the ray hits something
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~playerLayer))
        {
            // Check if the hit object is the player
            if (hit.transform == player)
            {
                return true; // Player is behind the object
            }
        }

        return false; // Player is not behind the object
    }
}
