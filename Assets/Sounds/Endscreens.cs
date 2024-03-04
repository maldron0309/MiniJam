using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscreens : MonoBehaviour
{
    public GameObject endScreen1;
    public GameObject endScreen2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScreen());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeScreen()
    {
        yield return new WaitForSeconds(7);
        endScreen1.SetActive(false);
        endScreen2.SetActive(true);
        yield return new WaitForSeconds(6);
        Application.Quit();
    }
}
