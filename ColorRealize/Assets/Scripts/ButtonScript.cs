using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string scene;    //移動するシーンの名前

    public void OnClick()
    {
        SceneManager.LoadScene(scene);
    }
}
