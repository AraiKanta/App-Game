using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>崩れる物のレバースイッチのアクティブ非アクティブさせるやつ</summary>
public class CrumblingFloorSwitch : MonoBehaviour
{
    /// <summary>黒のレバースイッチ</summary>
    private GameObject _switchSpriteBlack;
    /// <summary>白のレバースイッチ</summary>
    private GameObject _switchSpriteWhite;
    /// <summary>崩れる床</summary>
    private GameObject _crumblingFloor;
    /// <summary>ボックスオブジェクト</summary>
    private GameObject _box;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] private GameObject[] _switchSprites;

    void Start()
    {
        _switchSpriteBlack = GameObject.Find("LeverSwitch_Black");
        //_switchSpriteWhite = GameObject.Find("LeverSwitch_White");
        _crumblingFloor = GameObject.Find("CrumblingFloor");
        _box = GameObject.Find("Box");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in _switchSprites)
            {
                item.SetActive(true);
                Destroy(_crumblingFloor);
                Destroy(_box);
            }
            _switchSpriteBlack.SetActive(false);
            //_switchSpriteWhite.SetActive(false);
        }
    }
}
