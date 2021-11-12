using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject sousaPanel; //��������̉��
    [SerializeField] GameObject menuPanel;  //���j���[�̉�ʁi�P�ԍŏ��̉�ʁj
    [SerializeField] GameObject titleCheckPanel;    //�^�C�g�����ӂ̉��

    //���ʉ��֘A
    [SerializeField] AudioClip buttonSound;   //�{�^�����������Ƃ��̉�
    MyPlayOneShot soundScript;
    [SerializeField] float volume;  //����

    private void Start()
    {
        soundScript = GameObject.Find("AudioManager").GetComponent<MyPlayOneShot>();
    }

    /*�^�C�g���{�^�����N���b�N
     * �^�C�g���m�F��ʂ�\��
     * ���j���[��ʂ��\��
     */
    public void ClickTitleButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //���ʉ���炷
        titleCheckPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    
    //�^�C�g���J��
    public void MoveTitleScene()
    {
        soundScript.SoundEfect(buttonSound, volume);    //���ʉ���炷
        SceneManager.LoadScene("Title");
    }

    /*��������{�^�����N���b�N
     *���������ʂ�\��
     *���j���[��ʂ��\��
     */
    public void ClickSetsumeiButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //���ʉ���炷
        sousaPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ClickBackTitleButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //���ʉ���炷
        titleCheckPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    /*�߂�{�^�����N���b�N
     *���j���[��ʂ�\��
     *����������\��
     */
    public void ClickBackSetumeiButton()
    {
        soundScript.SoundEfect(buttonSound, volume);    //���ʉ���炷
        sousaPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
