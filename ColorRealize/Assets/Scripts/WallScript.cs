using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private Library.EnemyColors wallColor;
    [SerializeField] Material[] materials;
    Collider2D wallCollider;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        wallCollider = GetComponent<Collider2D>();
        if(wallColor == Library.EnemyColors.YELLOW)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.YELLOW];
        }
        else if (wallColor == Library.EnemyColors.MAGENTA)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.MAGENTA];
        }
        else if (wallColor == Library.EnemyColors.CYAN)
        {
            gameObject.GetComponent<Renderer>().material = materials[(int)Library.EnemyColors.CYAN];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //�v���C���[�̐F���m�F����
            CheckColor();
        }
    }

    //�F�𔻒f���v���C���[��ʂ��������߂�
    void CheckColor()
    {
        switch (wallColor)
        {
            case Library.EnemyColors.YELLOW: //�C�G���[
                if(playerController.playerStatus.color == Library.PlayerColors.RED ||
                    playerController.playerStatus.color == Library.PlayerColors.GREEN) 
                {
                    wallCollider.isTrigger = true;
                }
                break;
            case Library.EnemyColors.MAGENTA: //�}�[���^
                if (playerController.playerStatus.color == Library.PlayerColors.RED ||
                    playerController.playerStatus.color == Library.PlayerColors.BLUE)
                {
                    wallCollider.isTrigger = true;
                }
                break;
            case Library.EnemyColors.CYAN: //�V�A��
                if (playerController.playerStatus.color == Library.PlayerColors.BLUE ||
                    playerController.playerStatus.color == Library.PlayerColors.GREEN)
                {
                    wallCollider.isTrigger = true;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            wallCollider.isTrigger = false;
        }
    }
}
