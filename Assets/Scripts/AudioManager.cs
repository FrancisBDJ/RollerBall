using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject _audioManagerGameObject;
    public static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        _audioManagerGameObject = GameObject.Find("Audio Manager");
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(_audioManagerGameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
