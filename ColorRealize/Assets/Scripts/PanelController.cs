using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    
  [SerializeField]public GameObject Panel1;
  [SerializeField] public GameObject Panel2;
  [SerializeField] public GameObject Panel3;
  [SerializeField] public GameObject Panel4;

    void Start()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    public void PanelChange2()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    public void PanelChange3()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(true);
        Panel4.SetActive(false);
    }

    public void PanelChange4()
    {
        Panel1.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(true);
    }

    public void SceneChanger()
    {
        SceneManager.LoadScene("Sample_Play");
    }
}
