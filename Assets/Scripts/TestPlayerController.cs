using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerController : MonoBehaviour
{
    [Header("X軸方向に加える力")]
    [SerializeField] float MoveX;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        rb2d.velocity = new Vector2(MoveX, rb2d.velocity.y); 
            
    }

    private void Jump()
    {

    }
}
