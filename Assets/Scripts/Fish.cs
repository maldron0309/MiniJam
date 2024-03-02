using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private GameObject harpoon;
    [SerializeField] private float speed = 5f;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector3(1.66f, -3.01f, transform.position.z);
    }

    private void Update()
    {
        Animator Harpoon = harpoon.GetComponent<Animator>();
        if (Harpoon.GetCurrentAnimatorStateInfo(0).IsName("Harpoon Lowering"))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Harpoon"))
        {
            Debug.Log("Fish caught by harpoon!");
        }
    }
}
