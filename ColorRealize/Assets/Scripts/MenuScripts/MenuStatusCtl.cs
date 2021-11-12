using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusCtl : MonoBehaviour
{
    //メニュー画面で使うもの
    private Text hpText;  //HPテキスト
    private Text redGageText;   //赤ゲージの残り残量
    private Text blueGageText;  //青ゲージの残り残量
    private Text greenGageText; //緑ゲージの残り残量

    private void Update()
    {
        SetTextHp(10);
        SetTextRedGage(20);
        SetTextBlueGage(30);
        SetTextGreenGage(40);
    }

    void SetTextHp(int playerHp)
    {
        hpText = GameObject.Find("HPText").GetComponent<Text>();
        hpText.text = "HP：" + playerHp;
    }

    void SetTextRedGage(int redGage)
    {
        redGageText = GameObject.Find("redGageText").GetComponent<Text>();
        redGageText.text = "赤：" + redGage;
    }

    void SetTextBlueGage(int blueGage)
    {
        blueGageText = GameObject.Find("blueGageText").GetComponent<Text>();
        blueGageText.text = "青：" + blueGage;
    }

    void SetTextGreenGage(int greenGage)
    {
        greenGageText = GameObject.Find("greenGageText").GetComponent<Text>();
        greenGageText.text = "緑：" + greenGage;
    }
}
