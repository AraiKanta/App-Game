using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TestPlayerController : MonoBehaviour
{
    [Header("X軸方向に加える力")]
    [SerializeField] float MoveX;
    [Header("接地判定")]
    public GroundCheck groundCheck;
    [Header("重力")]
    public float gravityY;

    private Rigidbody2D _rb2d = null;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        //オートランさせているところ
        _rb2d.velocity = new Vector2(MoveX, _rb2d.velocity.y);

        Physics2D.gravity = new Vector2(0, gravityY);
    }

    //　DeadTileの当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadTile")
        {
            Destroy(gameObject);
            Debug.Log("Player Dead");
        }
    }

    //重力反転
    public void OnClick()
    {
        gravityY = -gravityY;
    }
}
