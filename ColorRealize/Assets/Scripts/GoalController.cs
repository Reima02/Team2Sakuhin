using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField] private string sceneName = "END";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == playerTag)
        {
            //ƒS[ƒ‹‘JˆÚ
            SceneManager.LoadScene(sceneName);
        }
    }
}
