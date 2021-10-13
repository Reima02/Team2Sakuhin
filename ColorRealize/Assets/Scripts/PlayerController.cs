using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus
{
    public int hp;
    public int atk;
    public int zanki;
    public Library.PlayerColors color;
    public int redGage;
    public int blueGage;
    public int greenGage;
    public int gageMax = 10;
    public Library.BulletTypes bulletType;
    public bool isRight = true;
}//プレイヤーのステータス

public class PlayerController : MonoBehaviour
{
    public PlayerStatus playerStatus = new PlayerStatus();    //プレイヤーステータス

    [SerializeField] private float moveSpeed = 0f;  //移動速度
    [SerializeField] float flap = 1000f;
    private Rigidbody2D rb;

    //プレイヤー初期設定
    [SerializeField] private int maxHP;

    //動く速さ
    private float XSpeed;

    //フラグ
    private bool isJump = false;  //ジャンプ中かの判定

    //色変え
    //[SerializeField] private Material[] materials;

    //弾をプレハブ
    private GameObject hgPrefab;
    private GameObject smgPrefab;
    private GameObject sgPrefab;
    private GameObject sgUpPrefab;
    private GameObject sgDownPrefab;
    private GameObject srPrefab;

    //弾の生成を制御
    private bool isBullet;
    [SerializeField] private float resetBulletTime; //生成速度を決める
    [SerializeField] private float hgResetTime;     //ハンドガンの発射レート
    [SerializeField] private float smgResetTime;    //サブマシンガンの発射レート
    [SerializeField] private float sgResetTime;     //ショットガンの発射レート
    [SerializeField] private float srResetTime;     //スナイパーの発射レート

    //ゲージ設定
    GameObject redGageObj;
    GameObject blueGageObj;
    GameObject greenGageObj;
    GameObject hpGageObj;

    //ダメージ設定
    bool isDamage = true;
    float damageResetTime = 1.0f;

    //アニメーション
    private Animator anim = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //弾の初期化
        hgPrefab = Resources.Load("HGBullet") as GameObject;
        smgPrefab = Resources.Load("HGBullet") as GameObject;
        sgPrefab = Resources.Load("SGBullet") as GameObject;
        sgUpPrefab = Resources.Load("SGBulletUp") as GameObject;
        sgDownPrefab = Resources.Load("SGBulletDown") as GameObject;
        srPrefab = Resources.Load("SRBullet") as GameObject;

        //プレイヤーデータの初期化
        playerStatus.redGage = playerStatus.gageMax;
        playerStatus.blueGage = playerStatus.gageMax;
        playerStatus.greenGage = playerStatus.gageMax;
        playerStatus.bulletType = Library.BulletTypes.HG;
        playerStatus.hp = maxHP;

        //ゲージの初期化
        redGageObj = GameObject.Find("RedGage");
        blueGageObj = GameObject.Find("BlueGage");
        greenGageObj = GameObject.Find("GreenGage");
        hpGageObj = GameObject.Find("HPGage");
    }

    private void Update()
    {
        if (isDamage)
        {
            Walk(); //歩き処理
            Jump(); //ジャンプ処理
            rb.velocity = new Vector2(XSpeed, rb.velocity.y);

            Attack();//攻撃
            ChangeColorProc();  //マウスホイールで色を変える

        }
    }

    //ゲージの回復
    public void GageHeal(Library.PlayerColors getColor)
    {
        switch(getColor)
        {
            case Library.PlayerColors.RED: //RED
                if (playerStatus.redGage < playerStatus.gageMax)
                {
                    playerStatus.redGage++;
                    redGageObj.GetComponent<GageScript>().GageDown(playerStatus.redGage, playerStatus.gageMax);   //ゲージUIの変更
                }
                break;
            case Library.PlayerColors.BLUE: //BLUE
                if (playerStatus.blueGage < playerStatus.gageMax)
                {
                    playerStatus.blueGage++;
                    blueGageObj.GetComponent<GageScript>().GageDown(playerStatus.blueGage, playerStatus.gageMax);   //ゲージUIの変更
                }
                break;
            case Library.PlayerColors.GREEN: //GREEN
                if (playerStatus.greenGage < playerStatus.gageMax)
                {
                    playerStatus.greenGage++;
                    greenGageObj.GetComponent<GageScript>().GageDown(playerStatus.greenGage, playerStatus.gageMax);   //ゲージUIの変更
                }
                break;
            default:
                break;
        }
    }

    //攻撃
    //左クリックを押したとき弾を発射
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isBullet)
            {
                isBullet = true;
                ColorGageProc();    //ゲージを減らす
                Invoke("ResetBullet", resetBulletTime);
            }
        }
    }

    //弾を生成する関数
    private void CreateBullet(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation); //弾を生成
    }


    //弾の生成速度を遅らせる関数
    void ResetBullet()
    {
        isBullet = false;
    }

    private void ColorGageProc()
    {
        switch (playerStatus.color)
        {
            case Library.PlayerColors.RED: //RED
                playerStatus.redGage = CheckBulletType(playerStatus.redGage);
                redGageObj.GetComponent<GageScript>().GageDown(playerStatus.redGage, playerStatus.gageMax);   //ゲージUIの変更
                break;

            case Library.PlayerColors.BLUE: //BLUE
                playerStatus.blueGage = CheckBulletType(playerStatus.blueGage);
                blueGageObj.GetComponent<GageScript>().GageDown(playerStatus.blueGage, playerStatus.gageMax);   //ゲージUIの変更
                break;
            case Library.PlayerColors.GREEN: //GREEN
                playerStatus.greenGage = CheckBulletType(playerStatus.greenGage);
                greenGageObj.GetComponent<GageScript>().GageDown(playerStatus.greenGage, playerStatus.gageMax);   //ゲージUIの変更
                break;
        }
    }

    /*弾の種類を判断
     * 引数：プレイヤーの色に対応したゲージの量
     * 戻り値：消費した後のゲージ量
     */
    int CheckBulletType(int gageNum)
    {
        switch(playerStatus.bulletType)
        {
            case Library.BulletTypes.HG:    //ハンドガンの場合
                if(gageNum >= 1)
                {
                    gageNum--;
                    CreateBullet(hgPrefab); //弾の生成
                    resetBulletTime = hgResetTime;  //発射レートの設定
                }
                break;
            case Library.BulletTypes.SMG:   //サブマシンの場合  
                if(gageNum >= 1)
                {
                    gageNum--;
                    CreateBullet(hgPrefab); //弾の生成 
                    resetBulletTime = smgResetTime; //発射レートの設定
                }
                break;
            case Library.BulletTypes.SG:    //ショットガンの場合
                if(gageNum >= 3)
                {
                    gageNum -= 3;
                    CreateBullet(sgPrefab); //弾の生成
                    CreateBullet(sgUpPrefab); //弾の生成
                    CreateBullet(sgDownPrefab); //弾の生成
                    resetBulletTime = sgResetTime;  //発射レートの設定
                }
                break;
            case Library.BulletTypes.SR:    //スナイパーの場合
                if(gageNum >= 1)
                {
                    gageNum--;
                    CreateBullet(srPrefab); //弾の生成
                    resetBulletTime = srResetTime;  //発射レートの設定
                }
                break;
            default:
                break;
        }

        return gageNum; //ゲージの減りを返す
    }

    //キャラクターの武器を変更する関数
    public void ChengWeapon(Library.BulletTypes bulletType)
    {
        playerStatus.bulletType = bulletType;
    }


    //横移動
    private void Walk()
    {
        var horizontalKey = Input.GetAxis("Horizontal");

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(3, 3, 1);
            XSpeed = moveSpeed;
            anim.SetBool("isRun", true);
            playerStatus.isRight = true;
        }

        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            XSpeed = -moveSpeed;
            anim.SetBool("isRun", true);
            playerStatus.isRight = false;
        }

        else
        {
            XSpeed = 0.0f;
            anim.SetBool("isRun", false);

        }
    }

    //ジャンプ
    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && !isJump)
        {
            anim.SetBool("isJump", true);
            isJump = true;
            rb.AddForce(Vector2.up * flap);
        }
    }

    //マウスホイールで色を変える
    void ChangeColorProc()
    {
        float rotateSpeed = 10f;
        var mouseWheel = Input.GetAxis("Mouse ScrollWheel") * rotateSpeed;

        if(mouseWheel > 0)
        {
            playerStatus.color--;
        }
        else if(mouseWheel < 0)
        {
            playerStatus.color++;
        }

        if(playerStatus.color < Library.PlayerColors.RED)
        {
            playerStatus.color = Library.PlayerColors.GREEN;
        }

        else if (playerStatus.color > Library.PlayerColors.GREEN)
        {
            playerStatus.color = Library.PlayerColors.RED;
        }

        TextureChange();    //色を変える
    }

    //色を変える関数
    void TextureChange()
    {
        if(playerStatus.color == Library.PlayerColors.RED)
        {
            SetColorAnim();//色を変える
        }

        else if (playerStatus.color == Library.PlayerColors.BLUE)
        {
            SetColorAnim();//色を変える
        }

        else if (playerStatus.color == Library.PlayerColors.GREEN)
        {
            SetColorAnim();//色を変える
        }
    }

    //色を変える
    void SetColorAnim()
    {
        anim.SetInteger("Color", (int)playerStatus.color);
    }

    //ダメージ処理
    public void DamageProc(int damage)
    {
        if (isDamage) 
        {
            anim.SetBool("isHit", true);
            playerStatus.hp -= damage;
            hpGageObj.GetComponent<GageScript>().GageDown(playerStatus.hp,maxHP);
            isDamage = false;
            Invoke("DamageReset", damageResetTime);
            if(playerStatus.hp <= 0) { GameOverProc(); }      
        }
       
    }
    //ダメージ処理を遅らせる
    private void DamageReset()
    {
        isDamage = true;
        anim.SetBool("isHit", false);
    }

    //ゲームオーバー
    private void GameOverProc()
    {
        SceneManager.LoadScene("END");
    }

    //地面との接地判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isJump = true;
        }
    }
}
