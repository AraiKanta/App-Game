using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InversionButton : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("InversionButton Clicked(反転ボタンをクリックした)");

        GameObject grid = GameObject.Find("Grid");
        GameObject tileMap = grid.transform.GetChild(0).gameObject;
        GameObject tileMap1 = grid.transform.GetChild(1).gameObject;

        tileMap.SetActive(false);
        tileMap1.SetActive(true);
    }
}
