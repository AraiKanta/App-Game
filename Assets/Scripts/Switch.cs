using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>レバースイッチのアクティブ非アクティブさせるやつ</summary>
public class Switch : MonoBehaviour
{
    GameObject _switchSprite;
    GameObject _crumblingFloor;
    GameObject _box;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] GameObject[] _switchSprites;
    Animator _anim;

    void Start()
    {
        _switchSprite = GameObject.Find("LeverSwitch_Black");
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
                _box.SetActive("FallBolck");
            }
            _switchSprite.SetActive(false);
        }
    }
}
