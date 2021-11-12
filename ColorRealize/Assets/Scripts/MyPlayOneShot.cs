using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayOneShot : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    /*Œø‰Ê‰¹‚ð–Â‚ç‚·
     * soudioEfect : –Â‚ç‚·Œø‰Ê‰¹
     * volume : ‰¹—Ê
     */
    public void SoundEfect(AudioClip soundEfect,float volume)
    {
        audioSource.Stop();
        audioSource.volume = volume;
        audioSource.PlayOneShot(soundEfect);

    }
}
