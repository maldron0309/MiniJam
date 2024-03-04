using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioClip lastSound;
    public AudioSource winMiniGameSound;
    AudioSource audioSource;

    public bool fishCaught = false;

    public Transform minigameSpawnPoint;
    public GameObject minigamePrefab;

    public Harpoon harpoon;

    public int stage = 0;

    public GameObject[] fishInfo;
    public GameObject fishManager;

    bool showingCard = false;

    public bool holdingFish = false;

    public Player player;

    int extraRounds = 0;

    public GameObject finalShadow;

    public GameObject endGameScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(8);
        fishManager.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (showingCard)
            {
                fishInfo[stage].SetActive(false);
                // fishManager.SetActive(true);
                stage++;
                showingCard = false;
                player.enabled = true;
                holdingFish = true;
                harpoon.inMiniGame = false;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }

        }
    }

    public void FishCaught()
    {
        Debug.Log("Fish Caught");
        GameObject minigame = Instantiate(minigamePrefab, minigameSpawnPoint.position, Quaternion.identity) as GameObject;
        minigame.GetComponent<Minigame>().rounds = 3 + extraRounds;
        extraRounds += 1;
    }

    public void StartNextRound()
    {
        StartCoroutine(StartNextFish());
    }

    IEnumerator StartNextFish()
    {
        yield return new WaitForSeconds(Random.Range(5, 8));
        fishManager.SetActive(true);
        if (stage == 1)
        {
            ResetFishAnimBools();
            fishManager.GetComponent<Animator>().SetBool("ShowEel", true);
        }
        else if (stage == 2)
        {
            ResetFishAnimBools();

        }
        else if (stage == 3)
        {
            ResetFishAnimBools();
            fishManager.GetComponent<Animator>().SetBool("ShowBig1", true);
        }
        else if (stage == 4)
        {
            ResetFishAnimBools();
            fishManager.GetComponent<Animator>().SetBool("ShowEel", true);
        }
        else if (stage == 5)
        {
            ResetFishAnimBools();
            fishManager.GetComponent<Animator>().SetBool("ShowBig1", true);
        }
        else if (stage == 6)
        {
            ResetFishAnimBools();
            fishManager.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            fishManager.GetComponent<Animator>().SetBool("ShowBig2", true);
        }
    }

    public void FinishedMinigame()
    {
        harpoon.anim.SetBool("Lowered", false);
        fishManager.SetActive(false);
        fishInfo[stage].SetActive(true);
        showingCard = true;
        winMiniGameSound.Play();
        if (stage == 6)
        {
            EndGame();
        }
    }

    void ResetFishAnimBools()
    {
        foreach (AnimatorControllerParameter parameter in fishManager.GetComponent<Animator>().parameters)
        {
            fishManager.GetComponent<Animator>().SetBool(parameter.name, false);
        }
    }

    public void EndGame()
    {
        fishManager.SetActive(false);
        audioSource.clip = lastSound;
        audioSource.volume = 0.6f;
        audioSource.Play();
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(10);
        finalShadow.SetActive(true);
        yield return new WaitForSeconds(14);
        endGameScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Credits");
    }

}
