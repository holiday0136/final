using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Scrips : MonoBehaviour
{
    [SerializeField] GameObject firepunch;
    [SerializeField] Transform firepunchSpawn;
    [SerializeField] Transform firepunchSpawn2;
    [SerializeField] GameObject apu;
    // 버프 설정
    public float speed; // 속도
    int jumppower = 3; // 점프

    // 스텟 설정
    float cooltime = 1;
    float cooltime2 = 5;
    int life = 3; // 목숨

    // 이동 설정
    float vAxis;
    bool jDown;
    float isJump;
    Vector3 moveVector;

    Animator anim;


    Rigidbody rigid;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Jump();
        Attack();

        cooltime += Time.deltaTime;
        cooltime2 += Time.deltaTime;
    }


    void GetInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vAxis = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vAxis = 1;
        }
        else
        {
            vAxis = 0;
        }


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            jDown = true;
        }
        else
        {
            jDown = false;
        }

        if (vAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (vAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Move()
    {
        moveVector = new Vector3(0, 0, vAxis).normalized;

        transform.position += moveVector * speed * Time.deltaTime;

        anim.SetBool("Walk", moveVector != Vector3.zero);
    }


    void Jump()
    {
        if (jDown && isJump < 2)
        {
            rigid.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
            isJump += 1;
            anim.SetTrigger("Dojump");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = 0;
        }

        if (collision.gameObject.tag == "Superjump")
        {
            jumppower = 5;
            StartCoroutine("item");
        }

        if (collision.gameObject.tag == "Speed")
        {
            speed = 10;
            StartCoroutine("item");
        }

        if (collision.gameObject.tag == "Grow")
        {
            transform.localScale = new Vector3(3, 3, 3);
            StartCoroutine("item");
        }

        if (collision.gameObject.tag == "SkyDie")
        {
            skydie();
        }

        


    }
    IEnumerator item()
    {
        yield return new WaitForSecondsRealtime(5f);
        jumppower = 3;
        speed = 5;
        transform.localScale = new Vector3(1, 1, 1);
        yield return null;

    }

    void skydie()
    {
        life = life - 1;
        if (life == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("main 1");
        }
        transform.localPosition = new Vector3(0, 5, 0);
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (cooltime >= 1)
            {
                anim.SetTrigger("Punch");
                Instantiate(firepunch, firepunchSpawn.transform.position, firepunchSpawn.transform.rotation);
                cooltime = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (cooltime2 >= 5)
            {
                anim.SetTrigger("Upper");
                Instantiate(apu, firepunchSpawn2.transform.position, firepunchSpawn2.transform.rotation);
                cooltime2 = 0;
            }

        }

    }
}
