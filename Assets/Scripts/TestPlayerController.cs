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
    [Header("Jumpボタン")]
    [SerializeField] Button _jumpButton;

    private Rigidbody2D _rb2d = null;
    private bool isGrounded = false;
      
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _jumpButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        _rb2d.velocity = new Vector2(MoveX, _rb2d.velocity.y);

        isGrounded = groundCheck.IsGround();
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = new Vector2(MoveX, _rb2d.velocity.y);
    }

    void OnClick()
    {
        if (isGrounded)
        {
            _rb2d.AddForce(Vector2.up * jumpFroce);  //上方向へ力を加える。
            isGrounded = false;
        }     
    }
}
