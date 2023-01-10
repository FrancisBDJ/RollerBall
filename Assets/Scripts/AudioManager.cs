using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameObject _audioManagerGameObject;
    public static AudioManager Instance;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioManagerGameObject = GameObject.Find("Audio Manager");
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(_audioManagerGameObject);
        }
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
