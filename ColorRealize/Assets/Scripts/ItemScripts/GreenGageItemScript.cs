using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGageItemScript : MonoBehaviour
{
    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerObj.GetComponent<PlayerController>().GageHeal(Library.PlayerColors.GREEN);
            Destroy(gameObject);
        }
    }
}
