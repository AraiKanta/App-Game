using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InversionButton : MonoBehaviour
{
    GameObject tileMap;
    GameObject tileMap1;

    [SerializeField] Button _changeButton;
    void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        tileMap = grid.transform.GetChild(0).gameObject;
        tileMap1 = grid.transform.GetChild(1).gameObject;
        _changeButton.onClick.AddListener(OnClick);
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("InversionButton Clicked");

        tileMap.SetActive(false);
        tileMap1.SetActive(true);

        _changeButton.onClick.RemoveListener(OnClick);
        _changeButton.onClick.AddListener(ReverseOnClick);
    }

    public void ReverseOnClick() 
    {
        tileMap.SetActive(true);
        tileMap1.SetActive(false);
        _changeButton.onClick.RemoveListener(ReverseOnClick);
        _changeButton.onClick.AddListener(OnClick);
    }
}
