using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>障害物のレバースイッチのアクティブ非アクティブさせるやつ</summary>
public class ObstacleSwitch : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;
    /// <summary>黒のレバースイッチ</summary>
    private GameObject _switchSpriteBlack;
    /// <summary>白のレバースイッチ</summary>
    private GameObject _switchSpriteWhite;
    /// <summary>ボックスオブジェクト</summary>
    private GameObject _obstacle;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] private GameObject[] _switchSprites;

    bool isSwitch = false;

    void Start()
    {
        //_switchSpriteBlack = GameObject.Find("LeverSwitch_Black");
        _switchSpriteWhite = GameObject.Find("LeverSwitch_White");
        _obstacle = GameObject.Find("Obstacle");
    }

    public bool IsSwitch() 
    {
        obstacle.IsFall();

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
                //_switchSpriteBlack.SetActive(false);
                _switchSpriteWhite.SetActive(false);
            }  
        }
    }
}
