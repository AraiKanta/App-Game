﻿using System.Collections;
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
    [Header("プレイヤーがTransFormRotationX軸で回転している角度")]
    [SerializeField]private float rotationX = 0;
    /// <summary>animatorの変数</summary>
    Animator _anim;

    private Rigidbody2D _rb2d = null;

    bool isDead = false;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("Run", true);
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //オートランさせているところ
        _rb2d.velocity = new Vector2(MoveX, _rb2d.velocity.y);

        //プレイヤーのRotationXを回転させている
        this.transform.rotation = Quaternion.Euler(rotationX, 0, 0);

        Physics2D.gravity = new Vector2(0, gravityY);
    }

    //Deadのフラグ判定
    public bool IsDead() 
    {
        return isDead;
    }

    //　DeadTileの当たり判定
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadTile")
        {
            isDead = true;
            if (isDead)
            {
                Debug.Log("Player Dead");
            }

            _anim.SetTrigger("Dead");
        }
    }

    //重力反転
    public void OnClick()
    { 
        gravityY = -gravityY;
        rotationX = -rotationX + 180;
    }

    public void SetSteerActive(bool active) 
    {
        _rb2d.isKinematic = !active;
    }
}
