using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>ポーズUIを表示するやつ</summary>
public class PauseUI : MonoBehaviour
{
    [Header("パネル")]
    [SerializeField] private GameObject _pausePanel;
    [Header("ポーズのテキスト")]
    [SerializeField] private GameObject _text;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;
    [Header("ポーズボタン")]
    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(OnClick);
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

        _pauseButton.onClick.RemoveListener(OnClick);
        _pauseButton.onClick.AddListener(ReverseOnClick);
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

        _pauseButton.onClick.RemoveListener(ReverseOnClick);
        _pauseButton.onClick.AddListener(OnClick);
    }
}
