using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public AudioClip[] footStepSounds;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayRandomWalkSound()
    {
        audioSource.clip = footStepSounds[UnityEngine.Random.Range(0, footStepSounds.Length)];
        audioSource.Play();
    }
}
