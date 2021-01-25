using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerController : MonoBehaviour
{
    [Header("X軸方向に加える力")]
    [SerializeField] float MoveX;
    [Header("重力")]
    [SerializeField] float gravity;
    [Header("ジャンプ速度")]
    [SerializeField] float jumpSpeed;
    [Header("高さ制限")]
    [SerializeField] float jumpHeight;
    [Header("接地判定")]
    public GroundCheck groundCheck;

    private Rigidbody2D rb2d = null;
    private bool isGround = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
      
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGround = groundCheck.IsGround();

        float ySpeed = -gravity;
        float vertical = Input.GetAxis("Vertical");

        if (isGround)
        {
            if (vertical > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            if (vertical > 0 && jumpPos + jumpHeight > transform.position.y)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
        rb2d.velocity = new Vector2(MoveX, ySpeed);
    }
}
