using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayOneShot : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    /*���ʉ���炷
     * soudioEfect : �炷���ʉ�
     * volume : ����
     */
    public void SoundEfect(AudioClip soundEfect,float volume)
    {
        audioSource.Stop();
        audioSource.volume = volume;
        audioSource.PlayOneShot(soundEfect);

    }
}
