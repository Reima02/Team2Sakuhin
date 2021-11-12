using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUp : MonoBehaviour
{
    bool isMenu;    //メニュー表示中かの判定

    [SerializeField] GameObject menuUIObj;  //メニューUIのオブジェクト

    //効果音関係
    [SerializeField] AudioClip openMenuSound;   //メニュー表示の時の音
    [SerializeField] AudioClip cancelSound;     //メニューを閉じるときの音
    [SerializeField] float volume;  //音量

    public bool OpenMenu()
    {
        MyPlayOneShot soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenu = !isMenu;
            menuUIObj.SetActive(isMenu);
            if (isMenu) { soundScript.SoundEfect(openMenuSound, volume); }  //効果音：メニューを開くとき
            else { soundScript.SoundEfect(cancelSound, volume); }         //効果音：メニューを閉じるとき
        }
        return isMenu;
    }

}
