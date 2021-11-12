using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnButtonCursor : MonoBehaviour,IPointerEnterHandler
{
    //���ʉ��֌W
    [SerializeField] AudioClip cursorSound; //�J�[�\�����{�^���ɐG�ꂽ�Ƃ��̉�
    [SerializeField] float volume;  //���ʒ���
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("�{�^����cursor���G�ꂽ");
        MyPlayOneShot soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
        soundScript.SoundEfect(cursorSound, volume);
    }
}
