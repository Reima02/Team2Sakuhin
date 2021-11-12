using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;//���x
    public bool nonVisbleAct;//��ʊO�ł̓��� 

    //�G�������Ă��邩���f
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool IsRight = false;

    //�A�j���[�V����
    private Animator anim = null;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Black();
        //Cyan();
        //Magenta();
        //Yellow();

        //debug
        if (Input.GetKeyDown(KeyCode.E))
        {
            IsRight = !IsRight;
        }
    }

    //�u���b�N
    public void Black()
    {
        if (sr.isVisible || nonVisbleAct)
        {
            int xVector = -1;
            if (IsRight)
            {
                xVector = 1;
                anim.SetBool("IsRightBlack", false);
            }
            else
            {
                anim.SetBool("IsRightBlack", true);
            }
            rb.velocity = new Vector2(xVector * speed, 0);
        }
        else
        {
            rb.Sleep();
        }
    }

    //�V�A��
    public void Cyan()
    {
        if (sr.isVisible || nonVisbleAct)
        {
            int xVector = -1;
            if (IsRight)
            {
                xVector = 1;
                anim.SetBool("IsRightCyan", false);
            }
            else
            {
                anim.SetBool("IsRightCyan", true);
            }
            rb.velocity = new Vector2(xVector * speed, 0);
        }
        else
        {
            rb.Sleep();
        }
    }
    //�}�[���^
    public void Magenta()
    {
        if (sr.isVisible || nonVisbleAct)
        {
            int xVector = -1;
            if (IsRight)
            {
                xVector = 1;
                anim.SetBool("IsMagentaRight", false);
            }
            else
            {
                anim.SetBool("IsMagentaRight", true);
            }
            rb.velocity = new Vector2(xVector * speed, 0);
        }
        else
        {
            rb.Sleep();
        }
    }
    //�C�G���[
    public void Yellow()
    {
        if (sr.isVisible || nonVisbleAct)
        {
            int xVector = -1;
            if (IsRight)
            {
                xVector = 1;
                anim.SetBool("IsRightYellow", false);
            }
            else
            {
                anim.SetBool("IsRightYellow", true);
            }
            rb.velocity = new Vector2(xVector * speed, 0);
        }
        else
        {
            rb.Sleep();
        }
    }
}

