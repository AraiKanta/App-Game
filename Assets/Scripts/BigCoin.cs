using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigCoin : MonoBehaviour
{
    GameObject bigCoin;
    [SerializeField] GameObject[] bigCoinUI;
    void Start()
    {
        bigCoin = GameObject.Find("BigCoin"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in bigCoinUI)
            {
                item.SetActive(true);
            }
            bigCoin.SetActive(false);
        }
    }
}
