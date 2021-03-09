using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>障害物のレバースイッチのアクティブ非アクティブさせるやつ</summary>
public class ObstacleSwitch : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    /// <summary>黒のレバースイッチ</summary>
    private GameObject _switchSpriteBlack;
    /// <summary>白のレバースイッチ</summary>
    private GameObject _switchSpriteWhite;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] private GameObject[] _switchSprites;
    /// <summary>黒スイッチなら✅白なら□</summary>
    [Header("黒=True,白=false")]
    [SerializeField] private bool switchBool = false;
    /// <summary>フラグ</summary>
    bool isSwitch = false;

    void Start()
    {    
        if (switchBool == true)
        {
            _switchSpriteBlack = GameObject.Find("LeverSwitch_Black");
        }
        else
        {
            _switchSpriteWhite = GameObject.Find("LeverSwitch_White");
        }
    }
    public bool IsSwitch() 
    {
        _obstacle.IsFall();

        return isSwitch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "Player")
        {
            isSwitch = true;
            if (isSwitch)
            {
                foreach (var item in _switchSprites)
                {
                    item.SetActive(true);
                }

                if (switchBool == true)
                {
                    _switchSpriteBlack.SetActive(false);
                }
                else
                {
                    _switchSpriteWhite.SetActive(false);
                }    
            }    
        }
    }
}
