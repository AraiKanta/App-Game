﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    GameObject _itemCyan;
    [SerializeField] GameObject[] _itemUI;
    void Start()
    {
        _itemCyan = GameObject.Find("Items"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in _itemUI)
            {
                item.SetActive(true);
            }
            _itemCyan.SetActive(false);
        }
    }
}
