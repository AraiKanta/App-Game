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

    private Rigidbody2D rb2d = null;
      
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        rb2d.velocity = new Vector2(MoveX, rb2d.velocity.y);

        
    }
}
