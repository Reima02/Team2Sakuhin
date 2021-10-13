using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject playerObj;   //プレイヤーのオブジェクト

    private void Start()
    {
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //プレイヤーの移動に合わせてカメラを移動

    }

    private void Move()
    {
        Vector3 pos = playerObj.transform.position;
        pos.y += 2;
        pos.z = -10;
        gameObject.transform.position = pos;
    }
}
