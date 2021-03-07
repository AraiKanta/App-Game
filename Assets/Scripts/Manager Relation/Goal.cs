using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>ゴール時にUIを表示させるやつ</summary>
public class Goal : MonoBehaviour
{
    [Header("パネル")]
    [SerializeField] private GameObject _goalPanel;
    [Header("ゴールのテキスト")]
    [SerializeField] private GameObject _goalText;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;
    [Header("次のステージボタン")]
    [SerializeField] private GameObject _nextStage;
    bool isGoal = false;

    /// <summary>
    /// Goalのフラグ判定
    /// </summary>
    public bool IsGoal()
    {
        Time.timeScale = 0f;

        return isGoal;
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
}
