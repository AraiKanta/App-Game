using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{
    GameObject itemCyan;
    [SerializeField] GameObject[] itemUI;
    void Start()
    {
        itemCyan = GameObject.Find("Items (Cyan) (1)"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
