using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public GameObject _pausePanel;
    public GameObject _text;
    public GameObject _returnToTitle;
    public GameObject _retry;
    public Button _changeButton;

    private void Start()
    {
        _changeButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        // ポーズUIのアクティブ、非アクティブを切り替え
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        _text.SetActive(!_text.activeSelf);
        _returnToTitle.SetActive(!_returnToTitle.activeSelf);
        _retry.SetActive(!_retry.activeSelf);

        // ポーズUIが表示されているときは停止
        if (_pausePanel.activeSelf && _text.activeSelf && _returnToTitle && _retry)
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
        if (_pausePanel.activeSelf && _text.activeSelf && _returnToTitle && _retry)
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
            _text.SetActive(!_text.activeSelf);
            _returnToTitle.SetActive(!_returnToTitle.activeSelf);
            _retry.SetActive(!_retry.activeSelf);

            Time.timeScale = 1f;
        }

        _changeButton.onClick.RemoveListener(ReverseOnClick);
        _changeButton.onClick.AddListener(OnClick);
    }
}
