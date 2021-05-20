using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>UIのManagerクラス </summary>
public class UIManager : MonoBehaviour
{
    [Header("ポーズパネル")]
    [SerializeField] private GameObject _pausePanel;
    [Header("ポーズのテキスト")]
    [SerializeField] private GameObject _text;
    [Header("ポーズボタン")]
    [SerializeField] private Button _pauseButton;
    [Header("ゴールパネル")]
    [SerializeField] private GameObject _goalPanel;
    [Header("ゴールのテキスト")]
    [SerializeField] private GameObject _goalText;
    [Header("次のステージボタン")]
    [SerializeField] private GameObject _nextStage;
    [Header("ゲームオーバーパネル")]
    [SerializeField] private GameObject _gameOverPanel;
    [Header("ゲームオーバーのテキスト")]
    [SerializeField] private GameObject _gameOverText;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;
    bool isGoal = false;

    void Start()
    {
        _pauseButton.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// ゴールフラグ
    /// </summary>
    public bool IsGoal()
    {
        Time.timeScale = 0f;

        return isGoal;
    }

    /// <summary>
    /// ポーズUIを表示させるとこ
    /// </summary>
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

    /// <summary>
    /// GoalColliderの判定
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isGoal = true;
            if (isGoal)
            {
                Debug.Log("Goal");
            }

            // ポーズUIのアクティブ、非アクティブを切り替え
            _goalPanel.SetActive(!_goalPanel.activeSelf);
            _goalText.SetActive(!_goalText.activeSelf);
            _returnToTitle.SetActive(!_returnToTitle.activeSelf);
            _retry.SetActive(!_retry.activeSelf);
            _nextStage.SetActive(!_nextStage.activeSelf);

            // ポーズUIが表示されているときは停止
            if (_goalPanel.activeSelf && _goalText.activeSelf && _returnToTitle && _retry && _nextStage)
            {
                Time.timeScale = 0f;
            }
            // ポーズUIが表示されていないときは通常通り進行
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    /// <summary>
    /// 次のステージに進むボタン
    /// </summary>
    public void NextStageClick()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("Stage1");
    }

    /// <summary>
    /// ゲームオーバー時に表示させるとこ
    /// </summary>
    public void GameOver()
    {
        // ポーズUIのアクティブ、非アクティブを切り替え
        _gameOverPanel.SetActive(!_gameOverPanel.activeSelf);
        _gameOverText.SetActive(!_gameOverText.activeSelf);
        _returnToTitle.SetActive(!_returnToTitle.activeSelf);
        _retry.SetActive(!_retry.activeSelf);

        // ポーズUIが表示されているときは停止
        if (_gameOverPanel.activeSelf && _gameOverText.activeSelf && _returnToTitle && _retry)
        {
            Time.timeScale = 0f;
        }
        // ポーズUIが表示されていないときは通常通り進行
        else
        {
            Time.timeScale = 1f;
        }
    }

    //リトライ
    public void RetryClick()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("TestStage");
    }
}
