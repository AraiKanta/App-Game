using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    float alp;
    [Header("シーン遷移を開始するまでの時間")]
    public float fadeStartTime;
    [Header("Panelオブジェクト")]
    public GameObject Panel;

    void Start()
    {
        alp = Panel.GetComponent<Image>().color.a;
    }

    //フェードアウトの処理
    IEnumerator FadePanel()
    {
        while (alp < 1)
        {
            fadeStartTime += Time.deltaTime;
            Panel.GetComponent<Image>().color += new Color(0, 0, 0, 0.1f * fadeStartTime);
            alp += 0.01f;
            yield return null;
        }
        SceneManager.LoadScene("SelectScene");
    }

    public void OnClick()
    {
        StartCoroutine(FadePanel());
    }
}
