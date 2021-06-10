using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Scripts : MonoBehaviour
{
    public float speed;
    float vAxis;
    bool jDown;

    float isJump;
    int jumppower = 10;
    float redcooltime = 0;
    float bluecooltime = 0;
    float greencooltime = 0;

    Animator anim;

    Vector3 moveVector;

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
        StartCoroutine("item2");
    }

   
    void GetInput()
    {
        vAxis = Input.GetAxisRaw("Horizontal");
        jDown = Input.GetButtonDown("Jump");
        if (vAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
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
        if(collision.gameObject.tag == "Floor")
        {
            isJump = 0;
        }

         if(collision.gameObject.tag == "Superjump")
        {
            jumppower = 20;
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

        
    }
    IEnumerator item()
    {
        yield return new WaitForSecondsRealtime(5f);
        jumppower = 10;
        speed = 5;
        transform.localScale = new Vector3(1, 1, 1);
        yield return null;  

    }




}
