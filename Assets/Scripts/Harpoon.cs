using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] private GameObject fish; 
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        LowerHarpoon();
    }

    public void LowerHarpoon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Lowering Harpoon");
            anim.SetTrigger("Lower");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Fish caught!");
            anim.SetTrigger("Caught");

            if (Vector3.Distance(transform.position, fish.transform.position) < 0.1f)
            {
                Debug.Log("Fish");
            }
        }
    }
}
