using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeManager : MonoBehaviour
{
    [Header("トータル制限時間")]
    private float totalTime;
    [Header("制限時間（分）")] 
    [SerializeField] private int minute;
    [Header("制限時間（秒）")]
    [SerializeField] private float seconds;
    [Header("残り何秒でTimerTextが赤くなるか")]
    [SerializeField] float m_startWarning = 0f;
    [Header("残り何秒でTimeUPかを可視化するためのカラー変更")]
    [SerializeField] Color m_warningColor = Color.red;
    [Header("m_warningColorのアニメーション")]
    [SerializeField] Animator m_anim;
    [Header("CountDownTimer")]
    [SerializeField] private Text timerText;
    private float oldSeconds;

    [Header("パネル")]
    [SerializeField] private GameObject _timeUpPanel;
    [Header("タイムアップのテキスト")]
    [SerializeField] private GameObject _timeUpText;
    [Header("タイトルに戻るボタン")]
    [SerializeField] private GameObject _returnToTitle;
    [Header("リトライボタン")]
    [SerializeField] private GameObject _retry;


    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
        m_anim = GetComponent<Animator>(); 
    }


    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        if (totalTime < m_startWarning)
        {
            timerText.color = m_warningColor;
            if (m_anim)
            {
                m_anim.Play("Warning");
            }
        }
        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //　制限時間以下になったらコンソールに『GameOver』という文字列を表示する
        if (totalTime <= 0f)
        {
            Debug.Log("TIME UP だよ～ん");

            // ゲームオーバーUIのアクティブ、非アクティブを切り替え
            _timeUpPanel.SetActive(!_timeUpPanel.activeSelf);
            _timeUpText.SetActive(!_timeUpText.activeSelf);
            _returnToTitle.SetActive(!_returnToTitle.activeSelf);
            _retry.SetActive(!_retry.activeSelf);
            // ゲームオーバーUIが表示されているときは停止
            if (_timeUpPanel && _timeUpText && _returnToTitle && _retry)
            {
                Time.timeScale = 0f;
            }
            // ゲームオーバーUIが表示されていないときは通常通り進行
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
