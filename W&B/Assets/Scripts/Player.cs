using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float moveSpeed = 3f;
    public float JumpForce;
    public LayerMask chao;
    public Transform posPe;


    private Rigidbody2D rig;
    private Animator anim;

    private bool estaNoChao;
    private bool mudou;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Change();


    }

    void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

    }
    void Jump()
    {
        estaNoChao = Physics2D.OverlapCircle(posPe.position, 0.3f, chao);
        anim.SetBool("EstaNoChao", estaNoChao);
        anim.SetFloat("velocidadeY", rig.velocity.y);
        if (estaNoChao && Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = Vector2.up * JumpForce;
        }

    }
    void Change()
    {
        if (Input.GetKey("l"))
        {
            anim.SetTrigger("Transforma");
            mudou = true;
            anim.ResetTrigger("Transforma2");
        }
        if (Input.GetKey("k"))
        {
            anim.ResetTrigger("Transforma");
            mudou = false;
            anim.SetTrigger("Transforma2");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (mudou && collision.gameObject.tag == "dark")
        {
            moveSpeed = 0f;
            StartCoroutine(Die2());
            
        }

        if (!mudou && collision.gameObject.tag == "light")
        {
            moveSpeed = 0f;
            StartCoroutine(Die1());
            
        }
        if (collision.gameObject.tag == "hole")
        {
            moveSpeed = 0f;
            StartCoroutine(Die2());

        }

    }

    private IEnumerator Die2()
    {
        anim.SetTrigger("die2");
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
        Gamecontroller.instance.ShowGameOver();

    }
    private IEnumerator Die1()
    {
        anim.SetTrigger("die1");
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);
        Gamecontroller.instance.ShowGameOver();

    }
}