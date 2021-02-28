using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2 : MonoBehaviour
{
    GameObject itemCyan;
    [SerializeField] GameObject[] itemUI;
    void Start()
    {
        itemCyan = GameObject.Find("Items (2)"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in itemUI)
            {
                item.SetActive(true);
            }
            itemCyan.SetActive(false);
        }
    }
}
