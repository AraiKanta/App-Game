using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MoveSceneManager))]
///<summary> ゲームの進行を管理するクラス <summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("PlayerController")]
    public PlayerController _playerController;
    MoveSceneManager _moveSceneManager;

    bool isGameScene = false;
    bool oneUse = true;

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
    }

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestStage")
        {
            isGameScene = true;
        }
        else
        {
            isGameScene = false;
            oneUse = true;

            _playerController = null;
        }
        if (isGameScene && oneUse)
        {
            oneUse = false;
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    //GameOver
    public void LoadComponents() 
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
