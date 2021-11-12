using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUp : MonoBehaviour
{
    bool isMenu;    //���j���[�\�������̔���

    [SerializeField] GameObject menuUIObj;  //���j���[UI�̃I�u�W�F�N�g

    //���ʉ��֌W
    [SerializeField] AudioClip openMenuSound;   //���j���[�\���̎��̉�
    [SerializeField] AudioClip cancelSound;     //���j���[�����Ƃ��̉�
    [SerializeField] float volume;  //����

    public bool OpenMenu()
    {
        MyPlayOneShot soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = !isMenu;
            menuUIObj.SetActive(isMenu);
            if (isMenu) { soundScript.SoundEfect(openMenuSound, volume); }  //���ʉ��F���j���[���J���Ƃ�
            else { soundScript.SoundEfect(cancelSound, volume); }         //���ʉ��F���j���[�����Ƃ�
        }
        return isMenu;
    }

}
