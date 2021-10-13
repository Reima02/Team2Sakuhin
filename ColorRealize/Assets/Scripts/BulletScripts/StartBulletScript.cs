using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBulletScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float destoryTime = 2.0f;
    [SerializeField] Material[] materials;
    PlayerController playerController;
    Rigidbody2D rb;
    private Vector2 direction = Vector2.right;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //�v���C���[�̐F�ɍ��킹�ĐF��ς���
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
        direction = playerController.playerStatus.isRight ? Vector2.right : Vector2.left;

        Destroy(gameObject, destoryTime);

    }

    private void Update()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        rb.velocity = direction * moveSpeed;
    }

    //�ǂƓG�ɓ���������e������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall" || collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
