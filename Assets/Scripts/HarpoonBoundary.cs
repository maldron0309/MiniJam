using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonBoundary : MonoBehaviour
{
    [HideInInspector] public bool playerInBounds = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInBounds = false;
        }
    }
}
