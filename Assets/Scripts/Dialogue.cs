using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public TMP_Text text;
    public TMP_Text continueText;
    public string[] lines;
    public float textSpeed;
    int index;

    public LevelLoader levelLoader;

    void Start()
    {
        text.text = string.Empty;
        StartCoroutine(StartDisalogue());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                continueText.gameObject.SetActive(true);
                text.text = lines[index];
            }
        }
    }

    IEnumerator StartDisalogue()
    {
        yield return new WaitForSeconds(2);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            GetComponent<AudioSource>().pitch = Random.Range(0.4f, 1.7f);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(textSpeed);
        }
        continueText.gameObject.SetActive(true);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            continueText.gameObject.SetActive(false);
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            continueText.gameObject.SetActive(false);
            // gameObject.SetActive(false);
            GetComponent<Dialogue>().enabled = false;
            levelLoader.FadeToNextLevel();
        }
    }
}
