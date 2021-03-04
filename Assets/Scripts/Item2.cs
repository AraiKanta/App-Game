using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2 : MonoBehaviour
{
    private GameObject _itemCyan;
    [SerializeField] private GameObject[] _itemUI;
    void Start()
    {
        _itemCyan = GameObject.Find("Items (2)"); 
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
