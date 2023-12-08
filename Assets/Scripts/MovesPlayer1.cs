using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesPlayer1 : MonoBehaviour
{

    //Run
    public int runSpeed = 1;
    float horizontal;
    float vertical;
    Animator animator;
    bool facingRight;

    //Shield
    bool IsShielding;

    //Rollin'
    float countRollin = 0;

    //Jump
    public float jumpForce = 300;
    Rigidbody2D rigidbody1;
    float axisY;
    bool IsJumping;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody1 = GetComponent<Rigidbody2D>();
        rigidbody1.Sleep();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal != 0 ? horizontal : vertical));

        if (Input.GetButton("Shield") && (vertical == 0 && horizontal == 0))
        {
            IsShielding= true;
            animator.SetBool("Rollin", false);
            animator.SetBool("IsShielding", IsShielding);
        }
        else if (Input.GetButtonDown("Shield") && horizontal != 0 && !IsShielding)
        {
            countRollin = 0.5f;
            animator.SetFloat("Speed", 0.0f);
            animator.SetBool("Rollin", true);
        }
        else if (Input.GetButtonUp("Shield"))
        {
            IsShielding= false;
            animator.SetBool("IsShielding", IsShielding);
        }

        if (transform.position.y <= axisY)
            OnLanding();

        if (countRollin > 0)
        {
            animator.SetFloat("Speed", 0.0f);
            countRollin = countRollin - (1f * Time.deltaTime);
            if (countRollin <= 0)
                animator.SetBool("Rollin", false);

        }

        if (Input.GetButton("Jump") && !IsJumping)
        {
            axisY = transform.position.y;
            IsJumping = true;
            rigidbody1.gravityScale = 1.5f;
            rigidbody1.WakeUp();
            rigidbody1.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("IsJumping", IsJumping);
        }

        

    }

    void FixedUpdate()
    {
        if ((horizontal != 0 || vertical != 0) && !IsShielding)
        {
            Vector3 movement = new Vector3(horizontal * runSpeed, vertical * runSpeed, 0.0f);
            transform.position = transform.position + movement * Time.deltaTime;
        }
        Flip(horizontal);

       
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnLanding()
    {
        IsJumping= false;
        rigidbody1.gravityScale = 0f;
        rigidbody1.Sleep();
        axisY = transform.position.y;
        animator.SetBool("IsJumping", false);
    }
}
