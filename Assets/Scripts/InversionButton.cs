using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InversionButton : MonoBehaviour
{
    GameObject tileMap;
    GameObject tileMap1;
    GameObject DeadTile;
    GameObject DeadTile1;

    [SerializeField] Button _changeButton;

    void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        tileMap = grid.transform.GetChild(0).gameObject;
        tileMap1 = grid.transform.GetChild(1).gameObject;
        DeadTile = grid.transform.GetChild(2).gameObject;
        DeadTile1 = grid.transform.GetChild(3).gameObject;
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
        DeadTile.SetActive(false);
        DeadTile1.SetActive(true);

        _changeButton.onClick.RemoveListener(OnClick);
        _changeButton.onClick.AddListener(ReverseOnClick);
    }

    public void ReverseOnClick() 
    {
        Debug.Log("InversionButton Clicked");

        tileMap.SetActive(true);
        tileMap1.SetActive(false);
        DeadTile.SetActive(true);
        DeadTile1.SetActive(false);

        _changeButton.onClick.RemoveListener(ReverseOnClick);
        _changeButton.onClick.AddListener(OnClick);
    }
}
