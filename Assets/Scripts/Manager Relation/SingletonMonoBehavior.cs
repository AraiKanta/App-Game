using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// シングルトンパターンを実装する抽象クラス
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance 
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);
                _instance = (T)FindObjectOfType(t);
                if (_instance == null)
                {
                    Debug.LogWarning(t + "をアタッチしているGameObjectはありません");
                    return null;
                }
            }
            return _instance;  
        }
    }

    virtual protected void Awake()
    {
        if (this != Instance)
        {
            Debug.LogWarning(typeof(T) + "は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました"
                + "アタッチされているGameObjectは" + Instance.gameObject.name + "です");
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);は継承先で書く
    }
}
