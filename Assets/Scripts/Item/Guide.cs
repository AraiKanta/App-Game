using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    private GameObject _Guide;
    [SerializeField] private GameObject[] _GuideObj;
    void Start()
    {
        _Guide = GameObject.Find("GuideCollider"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in _GuideObj)
            {
                item.SetActive(true);
            }
            _Guide.SetActive(false);
        }
    }
}
