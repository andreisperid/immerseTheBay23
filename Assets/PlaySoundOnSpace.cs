using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnSpace : MonoBehaviour
{
    public AudioClip horseSound; // add sound
        private AudioSource audioSource;

    void Start()
    {
        //get audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(horseSound);
        }
    }
}