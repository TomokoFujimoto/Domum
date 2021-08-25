using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Rigidbody2D Barco;
    private Animator anim;
    
    [SerializeField]
    private int speed;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private BoxCollider2D groundCheck;

    private bool facingRight;

    private SpriteRenderer sprite;
    [SerializeField]
    private bool onBoard;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        grounded = true;
        jumping = false;
        onBoard = false;
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimations();

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
            grounded = false;

            if (onBoard == true)
            {
                onBoard = false;
            }
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);
        if (onBoard)
        {
            Barco.velocity = new Vector2(move * speed, rb2D.velocity.y);
        }

        if ((move > 0f && facingRight) || (move < 0f && !facingRight))
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (jumping)
        {
            jumping = false;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            rb2D.AddForce(new Vector2(0f, jumpforce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barco")
        {
            onBoard = true;
            grounded = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void SetAnimations()
    {
        anim.SetFloat("VelY", rb2D.velocity.y);
        if (rb2D.velocity.y > 0) Debug.Log(rb2D.velocity.y);
        anim.SetBool("JumpFall", !grounded);
    }
}
