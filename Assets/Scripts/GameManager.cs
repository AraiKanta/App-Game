using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("PlayerController")]
    public PlayerController _playerController;
    [Header("TimeManager")]
    public TimeManager _timeManager;
    [Header("パネル")]
    [SerializeField] private GameObject _gameOverPanel;
    [Header("ゲームオーバーのテキスト")]
    [SerializeField] private GameObject _gameOverText;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;
    [Header("パネル")]
    [SerializeField] private GameObject _GoalPanel;
    [Header("ゴールのテキスト")]
    [SerializeField] private GameObject _GoalText;
    [Header("次のステージボタン")]
    [SerializeField] private GameObject _nextStage;


    //ステート
    enum State 
    {   
        Ready,
        Play,
        GameOvar,
        Goal,
    }
    State state;

    void Start()
    {
        Ready();
        NextStageClick();

        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);   
    }

    void LateUpdate()
    {
        switch (state) 
        {
            case State.Ready:
                
                break;

            case State.Play:
                //if (_playerController.IsDead()) GameOver();
                break;

            case State.GameOvar:
                
                break;

            case State.Goal:

                break;
        }
    }

    //始まる前
    private void Ready() 
    {
        state = State.Ready;
        //_playerController.SetSteerActive(false);
    }

    //Start
    private void GameStart()
    {
        state = State.Play;
        //_playerController.SetSteerActive(true);
    }

    //GameOver
    public void GameOver() 
    {
        state = State.GameOvar;

        // ポーズUIのアクティブ、非アクティブを切り替え
        _gameOverPanel.SetActive(!_gameOverPanel.activeSelf);
        _gameOverText.SetActive(!_gameOverText.activeSelf);
        _returnToTitle.SetActive(!_returnToTitle.activeSelf);
        _retry.SetActive(!_retry.activeSelf);
        _nextStage.SetActive(!_nextStage.activeSelf);

        // ポーズUIが表示されているときは停止
        if (_gameOverPanel.activeSelf && _gameOverText.activeSelf && _returnToTitle && _retry && _nextStage)
        {
            Time.timeScale = 0f;
        }
        // ポーズUIが表示されていないときは通常通り進行
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Goal() 
    {
        // ポーズUIのアクティブ、非アクティブを切り替え
        _GoalPanel.SetActive(!_GoalPanel.activeSelf);
        _GoalText.SetActive(!_GoalText.activeSelf);
        _returnToTitle.SetActive(!_returnToTitle.activeSelf);
        _retry.SetActive(!_retry.activeSelf);

        // ポーズUIが表示されているときは停止
        if (_GoalPanel.activeSelf && _GoalText.activeSelf && _returnToTitle && _retry)
        {
            Time.timeScale = 0f;
        }
        // ポーズUIが表示されていないときは通常通り進行
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    //リトライ
    public void RetryClick() 
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("Test");
    }

    public void NextStageClick()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        SceneManager.LoadScene("Stage1");
    }
}
