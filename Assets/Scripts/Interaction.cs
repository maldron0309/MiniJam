using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private LayerMask detectionLayer;
    private const float detectionRadius = 0.2f;

    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                GameObject detectedObject = GetDetectedObject();
                if (detectedObject != null)
                {
                    if (detectedObject.CompareTag("FishBox"))
                    {
                        InteractWithFishBox(detectedObject);
                    }
                    else if (detectedObject.CompareTag("Harpoon"))
                    {
                        InteractWithHarpoon(detectedObject);
                    }
                }
            }
        }
    }

    private bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }

    private GameObject GetDetectedObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRadius, detectionLayer);
        if (colliders.Length > 0)
        {
            return colliders[0].gameObject;
        }
        return null;
    }

    private void InteractWithFishBox(GameObject fishBox)
    {
        Debug.Log("Interacting with Fish Box");
        // Add your logic to interact with the fish box here
    }

    private void InteractWithHarpoon(GameObject harpoon)
    {
        Debug.Log("Interacting with Harpoon");
        Harpoon harpoonScript = harpoon.GetComponent<Harpoon>();
        if (harpoonScript != null)
        {
            harpoonScript.LowerHarpoon();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
