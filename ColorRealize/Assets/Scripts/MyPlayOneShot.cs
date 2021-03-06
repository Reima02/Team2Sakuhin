using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayOneShot : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    /*効果音を鳴らす
     * soudioEfect : 鳴らす効果音
     * volume : 音量
     */
    public void SoundEfect(AudioClip soundEfect,float volume)
    {
        audioSource.Stop();
        audioSource.volume = volume;
        audioSource.PlayOneShot(soundEfect);

    }
}
