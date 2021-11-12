using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject sousaPanel; //操作説明の画面
    [SerializeField] GameObject menuPanel;  //メニューの画面（１番最初の画面）
    [SerializeField] GameObject titleCheckPanel;    //タイトル注意の画面

    //効果音関連
    [SerializeField] AudioClip buttonSound;   //ボタンを押したときの音
    MyPlayOneShot soundScript;
    [SerializeField] float volume;  //音量

    private void Start()
    {
        soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
    }

    /*タイトルボタンをクリック
     * タイトル確認画面を表示
     * メニュー画面を非表示
     */
    public void ClickTitleButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //効果音を鳴らす
        titleCheckPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    
    //タイトル遷移
    public void MoveTitleScene()
    {
        soundScript.SoundEfect(buttonSound, volume);    //効果音を鳴らす
        SceneManager.LoadScene("Title");
    }

    /*操作説明ボタンをクリック
     *操作説明画面を表示
     *メニュー画面を非表示
     */
    public void ClickSetsumeiButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //効果音を鳴らす
        sousaPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ClickBackTitleButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //効果音を鳴らす
        titleCheckPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    /*戻るボタンをクリック
     *メニュー画面を表示
     *操作説明を非表示
     */
    public void ClickBackSetumeiButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //効果音を鳴らす
        sousaPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
