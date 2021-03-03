using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>レバースイッチのアクティブ非アクティブさせるやつ</summary>
public class Switch : MonoBehaviour
{
    GameObject _switchSprite;
    GameObject _crumblingFloor;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] GameObject[] _switchSprites;

    void Start()
    {
        _switchSprite = GameObject.Find("LeverSwitch_Black");
        _crumblingFloor = GameObject.Find("CrumblingFloor");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in _switchSprites)
            {
                item.SetActive(true);
                Destroy(_crumblingFloor);
            }
            _switchSprite.SetActive(false);
        }
    }
}
