using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float destoryTime = 1.0f;
    [SerializeField] Material[] materials;
    PlayerController playerController;

    [SerializeField] float moveX;
    [SerializeField] float moveY;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //プレイヤーの色に合わせて色を変える
        if (playerController.playerStatus.color == Library.PlayerColors.RED)
        {
            GetComponent<Renderer>().material = materials[(int)Library.PlayerColors.RED];
        }
        else if (playerController.playerStatus.color == Library.PlayerColors.BLUE)
        {
            GetComponent<Renderer>().material = materials[(int)Library.PlayerColors.BLUE];
        }
        else if (playerController.playerStatus.color == Library.PlayerColors.GREEN)
        {
            GetComponent<Renderer>().material = materials[(int)Library.PlayerColors.GREEN];
        }
        moveSpeed = playerController.playerStatus.isRight ? moveSpeed * 1 : moveSpeed * -1;

        Destroy(gameObject, destoryTime);

    }

    private void Update()
    {
        transform.position += new Vector3(moveX,moveY,0) * Time.deltaTime * moveSpeed;
    }

    //壁と敵に当たったら弾を消す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
