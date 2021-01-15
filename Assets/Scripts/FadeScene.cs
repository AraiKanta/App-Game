using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    float alp;
    public float fadeStartTime;
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
        SceneManager.LoadScene("GameScene1");
    }

    public void OnClick()
    {
        StartCoroutine(FadePanel());
    }
}
