using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� �������� �ӵ��� ������ ���� �����ôٸ� rigid �κп��� gravity~ ���� ������ �ּ���
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer sr;

    //���� ����
    public float jumpPower = 10;
    public int maxJump = 1;
    int jumpCount = 0;

    public int maxHp;
    int currentHp;

    //������ ����
    public int Doll = 0;            //layer 15
    public int unicornHorns = 0;    //layer 16
    public int candle = 0;          //layer 17
    public int medicine = 0;        //layer 18

    //�� ���� ����
    public float invincibilityTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //���� ��ȯ
        if (Input.GetButton("Horizontal"))
        {
            //sr.flipX = Input.GetAxisRaw("Horizontal") == -1;
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetButton("Jump") && jumpCount < maxJump)
        {
            print("Jump");
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            jumpCount++;
        }

    }

    private void FixedUpdate()
    {
        /*
        //��Ʈ�ѿ� ���� �̵�
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //���ӵ� ������ ���� ĭ
        if (rigid.velocity.x > maxSpeed)    //����
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))    //������
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        */
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * maxSpeed, rigid.velocity.y);

        //###�����ɽ�Ʈ Ȯ��
        //���� �÷��� Ȯ��
        if (rigid.velocity.y < 0)
        {
            Debug.DrawLine(transform.position, new Vector3(0, 1, 0), new Color(0, 1, 0));
            RaycastHit2D rayHitDown = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")); //Layer �߰� �ٶ��ϴ�...!

            if (rayHitDown.collider != null)
            {
                if (rayHitDown.distance < 0.6)
                {
                    jumpCount = 0;
                    print("Down Hit: " + rayHitDown.collider.name);
                }
            }
        }
    }

    //�����۰� �浹 ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionedObject = collision.gameObject;

        if (collisionedObject.CompareTag("Item"))
        {
            collisionedObject.SetActive(false);
            switch (collisionedObject.layer)
            {
                case 15: Doll++; print("Doll"); break;
                case 16: unicornHorns++; print("Unicorn Horns");  break;
                case 17: candle++; print("candle"); break;
                case 18: medicine++; print("medicine"); break;
            }
        }
    }

    public void Attacked(int damage, Vector2 targetPos)
    {
        gameObject.layer = 25;
        sr.color = new Color(1, 1, 1, 0.4f);
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        print(dirc);
        rigid.AddForce(new Vector2(dirc, 1), ForceMode2D.Impulse);

        print("attacked");
        currentHp -= damage;
        if(currentHp < 0)
        {
            currentHp = 0;
        }

        Invoke("offDamaged", invincibilityTime);
    }

    void offDamaged()
    {
        gameObject.layer = 6;
        sr.color = new Color(1, 1, 1, 1);
    }
}
