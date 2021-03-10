using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>キャンバスでフェードイン、アウトさせるやつ </summary>
public class FadeCanvas : MonoBehaviour
{

    [System.NonSerialized]
    public bool fadeIn = false;
    [System.NonSerialized]
    public bool fadeOut = false;

    [SerializeField]
    Image _panelImage;
    [SerializeField]
    float fadeSpeed = 0.02f;

    float red, green, blue, alpha;

    //最初の処理
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //元の色を取得
        red = _panelImage.color.r;
        green = _panelImage.color.g;
        blue = _panelImage.color.b;
        alpha = _panelImage.color.a;
    }

    //毎フレームの処理
    void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else if (fadeOut)
        {
            FadeOut();
        }
    }

    //フェードイン
    void FadeIn()
    {
        alpha += fadeSpeed;

        SetAlpha();

        if (alpha >= 1)
        {
            fadeIn = false;
        }
    }

    //フェードアウト
    void FadeOut()
    {
        alpha -= fadeSpeed;

        SetAlpha();

        if (alpha <= 0)
        {
            fadeOut = false;

            Destroy(gameObject);
        }
    }

    //透明度を変更
    void SetAlpha()
    {
        _panelImage.color = new Color(red, green, blue, alpha);
    }
}