using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource playSound;

    [SerializeField]
    AudioClip music;

    private void Start()
    {
        playSound = GetComponent<AudioSource>();
    }

    public void DieSound()
    {
        playSound.PlayOneShot(music);
    }
}
