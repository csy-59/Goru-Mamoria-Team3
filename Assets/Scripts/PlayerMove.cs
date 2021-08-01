using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//만약 떨어지는 속도가 마음에 들지 않으시다면 rigid 부분에서 gravity~ 수를 조정해 주세요
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer sr;

    //점프 관련
    public float jumpPower = 10;
    public int maxJump = 1;
    int jumpCount = 0;

    public int maxHp;
    int currentHp;

    //아이템 관련
    public int Doll = 0;            //layer 15
    public int unicornHorns = 0;    //layer 16
    public int candle = 0;          //layer 17
    public int medicine = 0;        //layer 18

    //적 교전 관련
    public float invincibilityTime = 2;

    //NPC 인터랙션 관련
    NPCInteraction npc;
    public Text interText;
    bool textShowed = false;
    GameObject npcScan;

    //시작포인트 설정
    Vector2 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        npc = GetComponent<NPCInteraction>();
        startPoint = gameObject.transform.position;
        //interText.color = new Color(interText.color.r, interText.color.g, interText.color.b, 0f);

        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //방향 전환
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
        
        //컨트롤에 의한 이동
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * maxSpeed, rigid.velocity.y);

        //###레이케스트 확인
        //밟은 플렛폼 확인
        if (rigid.velocity.y < 0)
        {
            Debug.DrawLine(transform.position, new Vector3(0, 1, 0), new Color(0, 1, 0));
            RaycastHit2D rayHitDown = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform")); 

            if (rayHitDown.collider != null)
            {
                if (rayHitDown.distance < 0.6)
                {
                    jumpCount = 0;
                    print("Down Hit: " + rayHitDown.collider.name);
                }
            }
        }

        //앞에 있는 오브젝트 확인
        Debug.DrawLine(transform.position, new Vector3(1, 0, 0), new Color(1, 0, 0));
        RaycastHit2D rayHitNPC = Physics2D.Raycast(rigid.position, Vector3.right, 1, LayerMask.GetMask("InteractiveObject"));

        if(rayHitNPC.collider != null)
        {
            //print("Front Hit : " + rayHitNPC.collider.name);
        }
    }

    //아이템과 충돌 시
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionedObject = collision.gameObject;
        print(collisionedObject.tag);

        if (collisionedObject.CompareTag("Item"))
        {
            collisionedObject.SetActive(false);
            switch (collisionedObject.layer)
            {
                case 15: Doll++; print("Doll"); break;
                case 16: unicornHorns++; print("Unicorn Horns"); break;
                case 17: candle++; print("candle"); break;
                case 18: medicine++; print("medicine"); break;
            }
        }
        else if (collisionedObject.CompareTag("NPC"))
        {
            print(collisionedObject.name);
            collisionedObject.SetActive(false);

            if (!textShowed)
            {
                textShowed = true;
                interText.color = new Color(interText.color.r, interText.color.g, interText.color.b, 1f);
                Invoke("startFade", 2);
            }
        }
        else if (collisionedObject.CompareTag("StageEndPoint"))
        {
            Attacked(1, transform.position);
            gameObject.transform.position = startPoint;
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

    void startFade()
    {
        StartCoroutine(FadeTextToZero());
    }
    public IEnumerator FadeTextToZero()
    {
        interText.color = new Color(interText.color.r, interText.color.g, interText.color.b, 1);
        while (interText.color.a > 0.0f)
        {
            interText.color = new Color(interText.color.r, interText.color.g, interText.color.b, interText.color.a - (Time.deltaTime / 1));
            yield return null;
        }
    }
}
