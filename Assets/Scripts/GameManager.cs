using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("PlayerController")]
    public TestPlayerController _playerController;
    [Header("TimeManager")]
    public TimeManager _timeManager;

    //[Header("GameOverテキスト")]
    //[SerializeField] private Text gameOverText;
    //[Header("Scoreテキスト")]
    //[SerializeField] private Text scoreText;


    enum State 
    {   
        Ready,
        Play,
        GameOvar,
    }
    State state;

    void Start()
    {
        Ready();

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
                if (_playerController.IsDead()) GameOver();
                break;

            case State.GameOvar:
                
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
    private void GameOver() 
    {
        state = State.GameOvar;

    }

    private void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    //リトライ
    public void RetryClick() 
    {
        SceneManager.LoadScene("Test");
    }
}
