using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    GameObject switchSprite;
    GameObject crumblingFloor;
    [Header("非アクティブのSwitchオブジェクトを入れる")]
    [SerializeField] GameObject[] switchSprites;

    void Start()
    {
        switchSprite = GameObject.Find("LeverSwitch_Black");
        crumblingFloor = GameObject.Find("CrumblingFloor");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in switchSprites)
            {
                item.SetActive(true);
                Destroy(crumblingFloor);
            }
            switchSprite.SetActive(false);
        }
    }
}
