using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [Header("GameOverテキスト")]
    public Text gameOverText;
    [Header("Scoreテキスト")]
    public Text scoreText;

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
