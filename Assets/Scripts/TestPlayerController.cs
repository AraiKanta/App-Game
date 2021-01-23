using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerController : MonoBehaviour
{
    [Header("X軸方向に加える力")]
    [SerializeField] float MoveX;
    private Rigidbody2D rb2d = null;
    private SpriteRenderer spriteRenderer = null;  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        rb2d.velocity = new Vector2(MoveX, rb2d.velocity.y);

        Jump();
    }

    private void Jump()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && spriteRenderer.enabled == true)
        {
            Destroy(gameObject);
        }
    }
}
