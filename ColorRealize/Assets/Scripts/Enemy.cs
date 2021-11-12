using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;//速度
    public bool nonVisbleAct;//画面外での動き 

    //敵が見えているか判断
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool IsRight = false;

    //アニメーション
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

    //ブラック
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

    //シアン
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
    //マゼンタ
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
    //イエロー
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

