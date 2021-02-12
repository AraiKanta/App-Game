using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public GameObject _pauseUI;
    public GameObject _text;
    public Button _changeButton;

    private void Start()
    {
        _changeButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // ポーズUIのアクティブ、非アクティブを切り替え
        _pauseUI.SetActive(!_pauseUI.activeSelf);
        _text.SetActive(!_text.activeSelf);

        // ポーズUIが表示されているときは停止
        if (_pauseUI.activeSelf && _text.activeSelf)
        {
            Time.timeScale = 0f;
        }
        // ポーズUIが表示されていないときは通常通り進行
        else
        {
            Time.timeScale = 1f;
        }
        
        _changeButton.onClick.RemoveListener(OnClick);
        _changeButton.onClick.AddListener(ReverseOnClick);
    }
    public void ReverseOnClick() 
    {
        _changeButton.onClick.RemoveListener(ReverseOnClick);
        _changeButton.onClick.AddListener(OnClick);
    }
}
