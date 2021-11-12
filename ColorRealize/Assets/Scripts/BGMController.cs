using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{

    public bool DontDestroyEnabled = true;
    public AudioSource BGM_Title;
    public AudioSource BGM_Stage;

    private string beforeScene = "Explain";

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyEnabled)
        {
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(BGM_Title.gameObject);
        }

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        if(beforeScene == "Explain" && nextScene.name == "Sample_Play")
        {
            BGM_Title.Stop();
        }

        beforeScene = nextScene.name;
    }


    

}
