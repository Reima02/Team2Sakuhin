using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Library.EnemyColors enemyColor;
    [SerializeField] Material[] materials;
    PlayerController playerController;
    [SerializeField] float moveSpeed;
    [SerializeField] int damage;

    private void Start()
    {
        if (enemyColor == Library.EnemyColors.YELLOW)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.YELLOW];
        }
        else if (enemyColor == Library.EnemyColors.MAGENTA)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.MAGENTA];
        }
        else if (enemyColor == Library.EnemyColors.CYAN)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.CYAN];
        }
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        //����
        //Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            //�F���`�F�b�N
            ChackColor();
        }

        if(collision.tag == "Player")
        {
            playerController.DamageProc(damage);
        }
    }

    private void ChackColor()
    {
        switch (enemyColor)
        {
            case Library.EnemyColors.YELLOW: //�C�G���[
                if (playerController.playerStatus.color == Library.PlayerColors.BLUE)
                {
                    Destroy(gameObject);
                }
                break;
            case Library.EnemyColors.MAGENTA: //�}�[���^
                if (playerController.playerStatus.color == Library.PlayerColors.GREEN)
                {
                    Destroy(gameObject);
                }
                break;
            case Library.EnemyColors.CYAN: //�V�A��
                if (playerController.playerStatus.color == Library.PlayerColors.RED)
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
