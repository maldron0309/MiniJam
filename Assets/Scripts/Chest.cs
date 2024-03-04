using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject chestText;
    bool playerAtChest = false;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAtChest && GameManager.instance.holdingFish && Input.GetKeyDown(KeyCode.Space))
        {
            chestText.SetActive(false);
            audioSource.Play();
            GameManager.instance.holdingFish = false;
            if (GameManager.instance.stage != 7)
            {
                GameManager.instance.StartNextRound();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.instance.holdingFish == true)
        {
            chestText.SetActive(true);
            playerAtChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            chestText.SetActive(false);
            playerAtChest = false;
        }
    }


}
