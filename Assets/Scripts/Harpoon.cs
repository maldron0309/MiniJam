using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    public Animator anim;

    [SerializeField] HarpoonBoundary harpoonBoundary;
    [SerializeField] GameObject interactText;

    AudioSource audioSource;

    bool harpoonLowered = false;

    public Player player;

    public bool inMiniGame = false;

    bool stopShowingText = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (harpoonBoundary.playerInBounds)
        {
            if (!stopShowingText)
            {
                interactText.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !harpoonLowered && !GameManager.instance.holdingFish && !inMiniGame)
            {
                interactText.SetActive(false);
                stopShowingText = true;
                StartCoroutine(LowerHarpoon());
                audioSource.Play();
            }

        }
        else
        {
            stopShowingText = false;
            interactText.SetActive(false);
        }


    }

    IEnumerator LowerHarpoon()
    {
        harpoonLowered = true;
        player.enabled = false;
        player.GetComponentInChildren<Animator>().SetBool("isWalking", false);
        // freeze player in place
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        // player.GetComponent<Rigidbody2D>().isKinematic = true;
        anim.SetBool("Lowered", true);
        yield return new WaitForSeconds(1.5f);
        // unfreeze player
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.enabled = true;
        // player.GetComponent<Rigidbody2D>().isKinematic = false;
        anim.SetBool("Lowered", false);
        harpoonLowered = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            StopAllCoroutines();
            GameManager.instance.FishCaught();
            harpoonLowered = false;
            inMiniGame = true;
        }
    }

}
