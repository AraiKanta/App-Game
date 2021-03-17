using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MoveSceneManager))]
[RequireComponent(typeof(SaveManager))]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("PlayerController")]
    public PlayerController _playerController;
    MoveSceneManager _moveSceneManager;
    SaveManager _saveManager;

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
        _saveManager = GetComponent<SaveManager>();
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

    public void GameClear() 
    {
        
    }

    public void GameOver()
    {
        
    }

    public void Reload()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
