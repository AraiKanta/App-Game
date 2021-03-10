using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MoveSceneManager))]
//[RequireComponent(typeof(SaveManager))]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("PlayerController")]
    public PlayerController _playerController;
    [Header("パネル")]
    [SerializeField] private GameObject _gameOverPanel;
    [Header("ゲームオーバーのテキスト")]
    [SerializeField] private GameObject _gameOverText;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;

    MoveSceneManager _moveSceneManager;
    //SaveManager saveManager;

    //これこのゲームにはいらんかも
    //ステート
    //enum State 
    //{   
    //    Ready,
    //    Play,
    //    GameOvar,
    //}
    //State state;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);

        _moveSceneManager = GetComponent<MoveSceneManager>();
        //saveManager = GetComponent<SaveManager>();
    }

    void Start()
    {
        //Ready();  
    }

    //void LateUpdate()
    //{
    //switch (state) 
    //{
    //case State.Ready:

    //    break;

    //case State.Play:
    //    if (_playerController.IsDead()) GameOver();
    //    break;

    //case State.GameOvar:
    //    //if (_playerController.IsDead()) GameOver();
    //    break;
    //}
    //}

    //始まる前
    //private void Ready()
    //{
    //    state = State.Ready;
    //    _playerController.SetSteerActive(false);
    //}

    //Start
    //private void GameStart()
    //{
    //    state = State.Play;
    //    _playerController.SetSteerActive(true);
    //}

    //GameOver

    public void LoadComponents() 
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void GameOver() 
    {
        //state = State.GameOvar;

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

    public void Reload()
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

        SceneManager.LoadScene("TestStage");
    }
}
