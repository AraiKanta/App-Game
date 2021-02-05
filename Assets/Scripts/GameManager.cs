using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameOverテキスト")]
    [SerializeField] private Text gameOverText;
    [Header("Scoreテキスト")]
    [SerializeField] private Text scoreText;

    TimeManager timeManager;
    void Start()
    {
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    private void GameOver() 
    {
        
    }
}
