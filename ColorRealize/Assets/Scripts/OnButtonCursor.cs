using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnButtonCursor : MonoBehaviour,IPointerEnterHandler
{
    //効果音関係
    [SerializeField] AudioClip cursorSound; //カーソルがボタンに触れたときの音
    [SerializeField] float volume;  //音量調整
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("ボタンにcursorが触れた");
        MyPlayOneShot soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
        soundScript.SoundEfect(cursorSound, volume);
    }
}
