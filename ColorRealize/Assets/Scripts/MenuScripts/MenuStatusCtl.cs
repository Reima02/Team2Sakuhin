using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusCtl : MonoBehaviour
{
    //���j���[��ʂŎg������
    private Text hpText;  //HP�e�L�X�g
    private Text redGageText;   //�ԃQ�[�W�̎c��c��
    private Text blueGageText;  //�Q�[�W�̎c��c��
    private Text greenGageText; //�΃Q�[�W�̎c��c��

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
        hpText.text = "HP�F" + playerHp;
    }

    void SetTextRedGage(int redGage)
    {
        redGageText = GameObject.Find("redGageText").GetComponent<Text>();
        redGageText.text = "�ԁF" + redGage;
    }

    void SetTextBlueGage(int blueGage)
    {
        blueGageText = GameObject.Find("blueGageText").GetComponent<Text>();
        blueGageText.text = "�F" + blueGage;
    }

    void SetTextGreenGage(int greenGage)
    {
        greenGageText = GameObject.Find("greenGageText").GetComponent<Text>();
        greenGageText.text = "�΁F" + greenGage;
    }
}
