using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameManager gameManager;
    float moveX;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator anim;

    [Header("이동 속도")]
    [SerializeField][Range(100f, 800f)] float moveSpeed = 400f;

    [Header("점프 강도")]
    [SerializeField][Range(100f, 800f)] float jumpForce = 250f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    void Update()
    {
        if (anim == null) return;

        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


       if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
                // 점프 애니메이션 설정
                anim.SetBool("isJumping", true);
            }
        }
        else if (rb.velocity.y == 0)
        {
            // 착지 애니메이션 설정
            anim.SetBool("isJumping", false);
        }

        // Idle 애니메이션 설정
        if (Mathf.Abs(moveX) < 0.01f && rb.velocity.y == 0)
        {
            anim.SetBool("isIdle", true);
        }
        else
        {
            anim.SetBool("isIdle", false);
        }

        // 걷기 애니메이션 설정
        if (Mathf.Abs(moveX) > 0.01f && rb.velocity.y == 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
