using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{

    bool barAActive = false;
    bool barBActive = false;
    bool barCActive = false;

    bool barASelected = false;
    bool barBSelected = false;
    bool barCSelected = false;

    [SerializeField] GameObject barA;
    [SerializeField] GameObject barB;
    [SerializeField] GameObject barC;

    public int rounds = 1;


    void Start()
    {
        StartCoroutine(SelectNewBar());
    }


    public void toggleBarA()
    {
        barAActive = !barAActive;
    }

    public void toggleBarB()
    {
        barBActive = !barBActive;
    }

    public void toggleBarC()
    {
        barCActive = !barCActive;
    }

    IEnumerator SelectNewBar()
    {
        barASelected = false;
        barBSelected = false;
        barCSelected = false;
        barA.SetActive(false);
        barB.SetActive(false);
        barC.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        int randomBar = Random.Range(0, 3);
        switch (randomBar)
        {
            case 0:
                barASelected = true;
                barA.SetActive(true);
                break;
            case 1:
                barBSelected = true;
                barB.SetActive(true);
                break;
            case 2:
                barCSelected = true;
                barC.SetActive(true);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (barAActive && barASelected)
            {
                Debug.Log("Correct A");
                rounds--;
                if (rounds > 0)
                {
                    StartCoroutine(SelectNewBar());
                }
            }
            else if (barBActive && barBSelected)
            {
                Debug.Log("Correct B");
                rounds--;
                if (rounds > 0)
                {
                    StartCoroutine(SelectNewBar());
                }
            }
            else if (barCActive && barCSelected)
            {
                Debug.Log("Correct C");
                rounds--;
                if (rounds > 0)
                {
                    StartCoroutine(SelectNewBar());
                }
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
        if (rounds == 0)
        {
            GameManager.instance.FinishedMinigame();
            GameObject.Destroy(this.gameObject);
        }
    }

}
