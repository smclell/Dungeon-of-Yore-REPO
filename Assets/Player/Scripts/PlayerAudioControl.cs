using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioControl : MonoBehaviour
{
    [Header("Sounds:")]
    public AudioSource audioSource;
    public AudioClip meleeSound;
    public AudioClip fireballSound;
    public AudioClip slamSound;
    public AudioClip walkSound;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public float volume = 0.5f;

    public void MeleeSound() {    // play melee sound
        audioSource.PlayOneShot(meleeSound, volume);
    }public void FireballSound() { // play fireball sound
        audioSource.PlayOneShot(fireballSound, volume);
    }public void SlamSound() {     // play slam sound
        audioSource.PlayOneShot(slamSound, volume);
    }public void WalkSound() {     // play walk sound
        audioSource.PlayOneShot(walkSound, volume);
    }public void HitSound() {      //paly hit sound
        audioSource.PlayOneShot(hitSound, volume);
    }public void DeathSound() {    // play death sound
        audioSource.PlayOneShot(deathSound, volume);
    }

}
