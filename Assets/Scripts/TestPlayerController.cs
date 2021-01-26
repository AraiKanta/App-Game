using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerController : MonoBehaviour
{
    [Header("X軸方向に加える力")]
    [SerializeField] float MoveX;
    [Header("ジャンプ力")]
    [SerializeField] float jumpFroce = 0;
    [Header("地面のレイヤー")]
    public LayerMask groundLayer;
    [Header("接地判定")]
    public GroundCheck groundCheck;

    private Rigidbody2D rb2d = null;
    private bool isGrounded = false;
      
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2d.velocity = new Vector2(MoveX, rb2d.velocity.y);

        isGrounded = groundCheck.IsGround();

        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(MoveX, rb2d.velocity.y);
    }

    private void Jump() 
    {
        rb2d.AddForce(Vector2.up * jumpFroce);  //上方向へ力を加える。

        isGrounded = false;
    }
}
