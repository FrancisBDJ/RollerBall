using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollisions : MonoBehaviour
{
    private AudioSource _meteoriteAudioSource;
    [SerializeField] private AudioClip hitFloorAudioClip;
    [SerializeField] private AudioClip hitPlayerAudioClip;
    [SerializeField] private ParticleSystem hitFloorParticleSystem;
    [SerializeField] private ParticleSystem hitPlayerParticleSystem;

    void Start()
    {
        _meteoriteAudioSource = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _meteoriteAudioSource.PlayOneShot(hitPlayerAudioClip, 1.0f);
            Instantiate(hitPlayerParticleSystem, transform.position, Quaternion.identity);
            
        }
        
        if (collision.gameObject.CompareTag("Lava"))
        {
            _meteoriteAudioSource.PlayOneShot(hitFloorAudioClip, 1.0f);
            Instantiate(hitPlayerParticleSystem, transform.position, Quaternion.identity);
            
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            _meteoriteAudioSource.PlayOneShot(hitFloorAudioClip, 1.0f);
            Instantiate(hitFloorParticleSystem, transform.position, Quaternion.identity);
            
        }
        Destroy(gameObject, 0.5f);
    }
}
