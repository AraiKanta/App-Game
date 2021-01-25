using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    /// <summary>TileMapのtag</summary>
    private string groundTag = "Ground";
    /// <summary>接地判定</summary>
    private bool isGround = false;
    /// <summary>接地判定のフラグ</summary>
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //接地判定
    public bool IsGround() 
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
            Debug.Log("Now grounded");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
            Debug.Log("Keeps grounding");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
            Debug.Log("Not grounded");
        }
    }
}
